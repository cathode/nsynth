/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Text;

namespace NSynth
{
    /// <summary>
    /// Represents a buffer that primitive types can be decoded from/encoded to.
    /// </summary>
    public sealed class DataBuffer
    {
        #region Fields
        /// <summary>
        /// Holds the underlying byte array.
        /// </summary>
        private byte[] data;
        private int position;
        private ByteOrder mode;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBuffer"/> class.
        /// </summary>
        /// <param name="capacity">The fixed capacity of the buffer.</param>
        public DataBuffer(int capacity)
        {
            this.data = new byte[capacity];
            this.Mode = ByteOrder.System;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBuffer"/> class.
        /// </summary>
        /// <param name="capacity">The fixed capacity of the buffer.</param>
        /// <param name="mode">The endianness mode of the new instance.</param>
        public DataBuffer(int capacity, ByteOrder mode)
        {
            this.data = new byte[capacity];
            this.Mode = mode;
        }

        /// <summary>
        /// Initializes a new current of the <see cref="DataBuffer"/> class.
        /// </summary>
        /// <param name="contents"></param>
        public DataBuffer(byte[] contents)
        {
            this.data = contents;
            this.Mode = ByteOrder.System;
        }

        public DataBuffer(byte[] contents, ByteOrder mode)
        {
            this.data = contents;
            this.Mode = mode;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the underlying byte array of the current data buffer.
        /// </summary>
        public byte[] Contents
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value ?? new byte[0];
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ByteOrder"/> that determines the endianness of the data buffer.
        /// </summary>
        public ByteOrder Mode
        {
            get
            {
                return this.mode;
            }
            set
            {
                this.mode = (value == ByteOrder.System) ? (BitConverter.IsLittleEndian ? ByteOrder.LittleEndian : ByteOrder.BigEndian) : value;
            }
        }

        /// <summary>
        /// Gets or sets the position within the buffer where the next decode or encode will start.
        /// </summary>
        public int Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
        public int Length
        {
            get
            {
                return this.data.Length;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Reads the next byte from the buffer and advances the position by 1.
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            byte result = this.data[this.position];
            this.position += 1;
            return result;
        }

        /// <summary>
        /// Reads the specified number of bytes from the buffer and returns them as a new array.
        /// </summary>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>A new byte[] containing the bytes read from the buffer.</returns>
        public byte[] ReadBytes(int count)
        {
            int n = Math.Min(count, this.Length - this.Position);
            byte[] read = new byte[n];
            this.ReadBytes(read, 0, read.Length);
            return read;
        }

        /// <summary>
        /// Reads the specified number of bytes from the buffer, and writes them to the specified byte array.
        /// </summary>
        /// <param name="buffer">The byte[] where the bytes which are read will be written to.</param>
        /// <param name="startIndex">The index in <paramref name="buffer"/> at which to start writing to.</param>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>The number of bytes read.</returns>
        public int ReadBytes(byte[] buffer, int startIndex, int count)
        {
            int n = Math.Min(count, this.Length - this.Position);
            Array.Copy(this.data, this.position, buffer, startIndex, n);
            this.position += n;
            return n;
        }
        /// <summary>
        /// Decodes the next two bytes from the buffer as a 16-bit signed integer value,
        /// and advances the current position by two.
        /// </summary>
        /// <returns>The decoded 16-bit signed integer value.</returns>
        public short ReadInt16()
        {
            // No bitshift operator for short, have to use int and cast when returning.
            int result;

            if (this.Mode == ByteOrder.BigEndian)
                result = this.data[this.position] << 8
                       | this.data[this.position + 1];
            else
                result = this.data[this.position]
                       | this.data[this.position + 1] << 8;

            this.position += 2;
            return (short)result;
        }

        /// <summary>
        /// Decodes the next four bytes from the buffer as a 32-bit signed integer value,
        /// and advances the current position by four.
        /// </summary>
        /// <returns>The decoded 32-bit signed integer value.</returns>
        public int ReadInt32()
        {
            int result;

            if (this.Mode == ByteOrder.BigEndian)
                result = this.data[this.position + 0] << 24
                       | this.data[this.position + 1] << 16
                       | this.data[this.position + 2] << 8
                       | this.data[this.position + 3];

            else
                result = this.data[this.position + 0]
                       | this.data[this.position + 1] << 8
                       | this.data[this.position + 2] << 16
                       | this.data[this.position + 3] << 24;

            this.position += 4;
            return result;
        }

        /// <summary>
        /// Decodes the next eight bytes from the buffer as a 64-bit signed integer value,
        /// and advances the current position by eight.
        /// </summary>
        /// <returns>The decoded 64-bit signed integer value.</returns>
        public long ReadInt64()
        {
            long result;

            if (this.Mode == ByteOrder.BigEndian)
                result = this.data[this.position + 0] << 56
                       | this.data[this.position + 1] << 48
                       | this.data[this.position + 2] << 40
                       | this.data[this.position + 3] << 32
                       | this.data[this.position + 4] << 24
                       | this.data[this.position + 5] << 16
                       | this.data[this.position + 6] << 8
                       | this.data[this.position + 7];
            else
                result = this.data[this.position + 0]
                       | this.data[this.position + 1] << 8
                       | this.data[this.position + 2] << 16
                       | this.data[this.position + 3] << 24
                       | this.data[this.position + 4] << 32
                       | this.data[this.position + 5] << 40
                       | this.data[this.position + 6] << 48
                       | this.data[this.position + 7] << 56;

            this.position += 8;
            return result;
        }

        /// <summary>
        /// Decodes the next two bytes from the buffer as a 16-bit unsigned integer value,
        /// and advances the current position by two.
        /// </summary>
        /// <returns>The decoded 16-bit unsigned integer value.</returns>
        public ushort ReadUInt16()
        {
            // No bitshift operators for ushort, have to use int and cast when returning.
            int result;

            if (this.Mode == ByteOrder.BigEndian)
                result = (int)this.data[this.position + 0] << 8
                       | (int)this.data[this.position + 1];
            else
                result = (int)this.data[this.position + 0]
                       | (int)this.data[this.position + 1] << 8;

            this.position += 2;
            return (ushort)result;
        }

        /// <summary>
        /// Decodes the next four bytes from the buffer as a 32-bit unsigned integer value,
        /// and advances the current position by four.
        /// </summary>
        /// <returns>The decoded 32-bit unsigned integer value.</returns>
        public uint ReadUInt32()
        {
            uint result;

            if (this.Mode == ByteOrder.BigEndian)
                result = (uint)this.data[this.position + 0] << 24
                       | (uint)this.data[this.position + 1] << 16
                       | (uint)this.data[this.position + 2] << 8
                       | (uint)this.data[this.position + 3];

            else
                result = (uint)this.data[this.position + 0]
                       | (uint)this.data[this.position + 1] << 8
                       | (uint)this.data[this.position + 2] << 16
                       | (uint)this.data[this.position + 3] << 24;

            this.position += 4;
            return result;
        }

        /// <summary>
        /// Decodes the next eight bytes from the buffer as a 64-bit signed integer value,
        /// and advances the current position by eight.
        /// </summary>
        /// <returns>The decoded 64-bit signed integer value.</returns>
        public ulong ReadUInt64()
        {
            ulong result;

            if (this.Mode == ByteOrder.BigEndian)
                result = (ulong)this.data[this.position + 0] << 56
                       | (ulong)this.data[this.position + 1] << 48
                       | (ulong)this.data[this.position + 2] << 40
                       | (ulong)this.data[this.position + 3] << 32
                       | (ulong)this.data[this.position + 4] << 24
                       | (ulong)this.data[this.position + 5] << 16
                       | (ulong)this.data[this.position + 6] << 8
                       | (ulong)this.data[this.position + 7];

            else
                result = (ulong)this.data[this.position + 0]
                       | (ulong)this.data[this.position + 1] << 8
                       | (ulong)this.data[this.position + 2] << 16
                       | (ulong)this.data[this.position + 3] << 24
                       | (ulong)this.data[this.position + 4] << 32
                       | (ulong)this.data[this.position + 5] << 40
                       | (ulong)this.data[this.position + 6] << 48
                       | (ulong)this.data[this.position + 7] << 56;

            this.position += 8;
            return result;
        }

        public Guid ReadGuid()
        {
            return new Guid(this.ReadInt32(), this.ReadInt16(), this.ReadInt16(), this.ReadBytes(8));
        }

        public Version ReadVersion()
        {
            return new Version(this.ReadInt32(), this.ReadInt32(), this.ReadInt32(), this.ReadInt32());
        }

        public void WriteByte(byte value)
        {
            this.data[this.position] = value;
            this.position += 1;
        }
        /// <summary>
        /// Writes the specified 16-bit signed integer to the buffer and advances
        /// the current position by two.
        /// </summary>
        /// <param name="value">A 16-bit signed integer value to write to the buffer.</param>
        public void WriteInt16(short value)
        {
            if (this.Mode == ByteOrder.BigEndian)
            {
                this.data[this.position + 0] = (byte)(value >> 8);
                this.data[this.position + 1] = (byte)value;
            }
            else
            {
                this.data[this.position + 0] = (byte)value;
                this.data[this.position + 1] = (byte)(value >> 8);
            }

            this.position += 2;
        }

        /// <summary>
        /// Writes the specified 32-bit signed integer to the buffer and advances
        /// the current position by four.
        /// </summary>
        /// <param name="value">A 32-bit signed integer value to write to the buffer.</param>
        public void WriteInt32(int value)
        {
            if (this.Mode == ByteOrder.BigEndian)
            {
                this.data[this.position + 0] = (byte)(value >> 24);
                this.data[this.position + 1] = (byte)(value >> 16);
                this.data[this.position + 2] = (byte)(value >> 8);
                this.data[this.position + 3] = (byte)value;
            }
            else
            {
                this.data[this.position + 0] = (byte)value;
                this.data[this.position + 1] = (byte)(value >> 8);
                this.data[this.position + 2] = (byte)(value >> 16);
                this.data[this.position + 3] = (byte)(value >> 24);
            }

            this.position += 4;
        }

        /// <summary>
        /// Writes the specified 64-bit signed integer to the buffer and advances
        /// the current position by eight.
        /// </summary>
        /// <param name="value">A 64-bit signed integer value to write to the buffer.</param>
        public void WriteInt64(long value)
        {
            if (this.Mode == ByteOrder.BigEndian)
            {
                this.data[this.position + 0] = (byte)(value >> 56);
                this.data[this.position + 1] = (byte)(value >> 48);
                this.data[this.position + 2] = (byte)(value >> 40);
                this.data[this.position + 3] = (byte)(value >> 32);
                this.data[this.position + 4] = (byte)(value >> 24);
                this.data[this.position + 5] = (byte)(value >> 16);
                this.data[this.position + 6] = (byte)(value >> 8);
                this.data[this.position + 7] = (byte)value;
            }
            else
            {
                this.data[this.position + 0] = (byte)value;
                this.data[this.position + 1] = (byte)(value >> 8);
                this.data[this.position + 2] = (byte)(value >> 16);
                this.data[this.position + 3] = (byte)(value >> 24);
                this.data[this.position + 4] = (byte)(value >> 32);
                this.data[this.position + 5] = (byte)(value >> 40);
                this.data[this.position + 6] = (byte)(value >> 48);
                this.data[this.position + 7] = (byte)(value >> 56);
            }

            this.position += 8;
        }

        /// <summary>
        /// Writes the specified 16-bit unsigned integer to the buffer and advances
        /// the current position by two.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer value to write to the buffer.</param>
        public void WriteUInt16(ushort value)
        {
            if (this.Mode == ByteOrder.BigEndian)
            {
                this.data[this.position + 0] = (byte)(value >> 8);
                this.data[this.position + 1] = (byte)value;
            }
            else
            {
                this.data[this.position + 0] = (byte)value;
                this.data[this.position + 1] = (byte)(value >> 8);
            }

            this.position += 2;
        }

        /// <summary>
        /// Writes the specified 32-bit unsigned integer to the buffer and advances
        /// the current position by two.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer value to write to the buffer.</param>
        public void WriteUInt32(uint value)
        {
            if (this.Mode == ByteOrder.BigEndian)
            {
                this.data[this.position + 0] = (byte)(value >> 24);
                this.data[this.position + 1] = (byte)(value >> 16);
                this.data[this.position + 2] = (byte)(value >> 8);
                this.data[this.position + 3] = (byte)value;
            }
            else
            {
                this.data[this.position + 0] = (byte)value;
                this.data[this.position + 1] = (byte)(value >> 8);
                this.data[this.position + 2] = (byte)(value >> 16);
                this.data[this.position + 3] = (byte)(value >> 24);
            }

            this.position += 4;
        }

        /// <summary>
        /// Writes the specified 64-bit unsigned integer to the buffer and advances
        /// the current position by two.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer value to write to the buffer.</param>
        public void WriteUInt64(ulong value)
        {
            if (this.Mode == ByteOrder.BigEndian)
            {
                this.data[this.position + 0] = (byte)(value >> 56);
                this.data[this.position + 1] = (byte)(value >> 48);
                this.data[this.position + 2] = (byte)(value >> 40);
                this.data[this.position + 3] = (byte)(value >> 32);
                this.data[this.position + 4] = (byte)(value >> 24);
                this.data[this.position + 5] = (byte)(value >> 16);
                this.data[this.position + 6] = (byte)(value >> 8);
                this.data[this.position + 7] = (byte)value;
            }
            else
            {
                this.data[this.position + 0] = (byte)value;
                this.data[this.position + 1] = (byte)(value >> 8);
                this.data[this.position + 2] = (byte)(value >> 16);
                this.data[this.position + 3] = (byte)(value >> 24);
                this.data[this.position + 4] = (byte)(value >> 32);
                this.data[this.position + 5] = (byte)(value >> 40);
                this.data[this.position + 6] = (byte)(value >> 48);
                this.data[this.position + 7] = (byte)(value >> 56);
            }

            this.position += 8;
        }

        public int WriteStringAscii(string value)
        {
            throw new NotImplementedException();
        }

        public int WriteStringUtf8(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);

            if (this.position + this.data.Length > this.data.Length)
                throw new NotImplementedException();

            this.data.CopyTo(this.data, this.position);
            this.position += this.data.Length;
            return this.data.Length;
        }

        public int WriteStringUtf16(string value)
        {
            throw new NotImplementedException();
        }

        public int WriteBytes(byte[] value)
        {
            return this.WriteBytes(value, 0, value.Length);
        }

        public int WriteBytes(byte[] value, int startIndex, int count)
        {
            int n;
            for (n = 0; n < count; n++)
                this.data[this.position + n] = value[startIndex + n];

            this.position += n;
            return n;
        }

        public int WriteGuid(Guid id)
        {
            // Create a sub-buffer to decode the platform-specific result of Guid.ToByteArray()
            DataBuffer db = new DataBuffer(id.ToByteArray(), ByteOrder.System);

            this.WriteInt32(db.ReadInt32());
            this.WriteInt16(db.ReadInt16());
            this.WriteInt16(db.ReadInt16());
            this.WriteBytes(db.ReadBytes(8));

            return 16;
        }

        public int WriteVersion(Version version)
        {
            this.WriteInt32(version.Major);
            this.WriteInt32(version.Minor);
            this.WriteInt32(version.Build);
            this.WriteInt32(version.Revision);

            return 16;
        }
        #endregion
    }
}