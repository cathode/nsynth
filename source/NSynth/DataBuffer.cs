/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Text;
using System.Diagnostics.Contracts;

namespace NSynth
{
    /// <summary>
    /// Represents a buffer that primitive types can be decoded from/encoded to.
    /// </summary>
    [ContractVerification(true)]
    public sealed class DataBuffer
    {
        #region Fields
        /// <summary>
        /// Holds the underlying byte array.
        /// </summary>
        private readonly byte[] data;
        private int position;
        private ByteOrder mode;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBuffer"/> class.
        /// </summary>
        /// <param name="capacity">The capacity of the new instance.</param>
        public DataBuffer(int capacity)
        {
            Contract.Requires(capacity > 0);
            Contract.Ensures(this.Position == 0);
            Contract.Ensures(this.Available == capacity);

            this.data = new byte[capacity];
            this.Mode = ByteOrder.System;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBuffer"/> class.
        /// </summary>
        /// <param name="capacity">The capacity of the new instance.</param>
        /// <param name="mode">The endianness mode of the new instance.</param>
        public DataBuffer(int capacity, ByteOrder mode)
        {
            Contract.Requires(capacity > 0);
            Contract.Ensures(this.Position == 0);

            this.data = new byte[capacity];
            this.Mode = mode;
        }

        /// <summary>
        /// Initializes a new current of the <see cref="DataBuffer"/> class.
        /// </summary>
        /// <param name="contents">The byte array to initialize the new instance with.</param>
        public DataBuffer(byte[] contents)
        {
            Contract.Requires(contents != null);
            Contract.Requires(contents.Length > 0);
            Contract.Ensures(this.Position == 0);

            this.data = new byte[contents.Length];
            this.Mode = ByteOrder.System;
            contents.CopyTo(this.data, 0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBuffer"/> class.
        /// </summary>
        /// <param name="contents">The byte array to initialize the new instance with.</param>
        /// <param name="mode">The endianness mode of the new instance.</param>
        public DataBuffer(byte[] contents, ByteOrder mode)
        {
            Contract.Requires(contents != null);
            Contract.Requires(contents.Length > 0);
            Contract.Ensures(this.Position == 0);

            this.data = new byte[contents.Length];
            this.Mode = mode;
            contents.CopyTo(this.data, 0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBuffer"/> class.
        /// </summary>
        /// <param name="contents">The byte array to initialize the new instance with.</param>
        /// <param name="capacity">The capacity of the new instance.</param>
        public DataBuffer(byte[] contents, int capacity)
        {
            Contract.Requires(contents != null);
            Contract.Requires(capacity > 0);
            Contract.Ensures(this.Position == 0);

            this.data = new byte[capacity];
            this.Mode = ByteOrder.System;
            contents.CopyTo(this.data, 0);
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets a value that indicates how many bytes are available to be written to in the buffer.
        /// </summary>
        public int Available
        {
            get
            {
                return this.Capacity - this.Position;
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
                Contract.Ensures(Contract.Result<int>() <= this.data.Length);
                return this.position;
            }
            set
            {
                Contract.Requires(value <= this.Capacity);
                this.position = value;
            }
        }

        /// <summary>
        /// Gets the capacity of the current <see cref="DataBuffer"/>.
        /// </summary>
        public int Capacity
        {
            get
            {
                return this.data.Length;
            }
        }
        #endregion
        #region Methods

        public byte[] GetUnderlyingByteArray()
        {
            return this.data;
        }
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
            Contract.Ensures(Contract.Result<byte[]>() != null);

            int n = Math.Min(count, this.Capacity - this.Position);
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
            Contract.Requires(buffer != null);
            Contract.Requires(startIndex >= 0);

            if (count > 0)
            {
                int n = Math.Min(count, this.Capacity - this.Position);
                Array.Copy(this.data, this.position, buffer, startIndex, n);
                this.position += n;
                return n;
            }
            else
                return 0;
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
            Contract.Ensures(this.Position == Contract.OldValue<long>(this.Position) + 2);
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
            Contract.Requires(this.Capacity - this.Position >= 1);
            Contract.Ensures(this.Position == Contract.OldValue<int>(this.Position) + 1);
            this.data[this.position] = value;
            this.Position += 1;
        }
        /// <summary>
        /// Writes the specified 16-bit signed integer to the buffer and advances
        /// the current position by two.
        /// </summary>
        /// <param name="value">A 16-bit signed integer value to write to the buffer.</param>
        public void WriteInt16(short value)
        {
            Contract.Requires(this.Capacity - this.Position >= 2);
            Contract.Ensures(this.Position == Contract.OldValue<int>(this.Position) + 2);

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

            this.Position += 2;
        }

        /// <summary>
        /// Writes the specified 32-bit signed integer to the buffer and advances
        /// the current position by four.
        /// </summary>
        /// <param name="value">A 32-bit signed integer value to write to the buffer.</param>
        public void WriteInt32(int value)
        {
            Contract.Requires(this.Available >= 4);
            Contract.Ensures(this.Position == Contract.OldValue<int>(this.Position) + 4);

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

            this.Position += 4;
        }

        /// <summary>
        /// Writes the specified 64-bit signed integer to the buffer and advances
        /// the current position by eight.
        /// </summary>
        /// <param name="value">A 64-bit signed integer value to write to the buffer.</param>
        public void WriteInt64(long value)
        {
            Contract.Requires(this.Capacity - this.Position >= 8);
            Contract.Ensures(this.Position == Contract.OldValue<int>(this.Position) + 8);

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

            this.Position += 8;
        }

        /// <summary>
        /// Writes the specified 16-bit unsigned integer to the buffer and advances
        /// the current position by two.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer value to write to the buffer.</param>
        public void WriteUInt16(ushort value)
        {
            Contract.Requires(this.Capacity - this.Position >= 2);
            Contract.Ensures(this.Position == Contract.OldValue<int>(this.Position) + 2);

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

            this.Position += 2;
        }

        /// <summary>
        /// Writes the specified 32-bit unsigned integer to the buffer and advances
        /// the current position by two.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer value to write to the buffer.</param>
        public void WriteUInt32(uint value)
        {
            Contract.Requires(this.Capacity - this.Position >= 4);
            Contract.Ensures(this.Position == Contract.OldValue<int>(this.Position) + 4);

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

            this.Position += 4;
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

            this.Position += 8;
        }

        public int WriteStringAscii(string value)
        {
            Contract.Requires(value != null);

            throw new NotImplementedException();
        }

        public int WriteStringUtf8(string value)
        {
            Contract.Requires(value != null);

            var bytes = Encoding.UTF8.GetBytes(value);

            if (this.position + this.data.Length > this.data.Length)
                throw new NotImplementedException();

            bytes.CopyTo(this.data, this.position);
            this.position += bytes.Length;
            return this.data.Length;
        }

        public int WriteStringUtf16(string value)
        {
            Contract.Requires(value != null);

            throw new NotImplementedException();
        }

        public int WriteBytes(byte[] array)
        {
            Contract.Requires(array != null);

            return this.WriteBytes(array, 0, array.Length);
        }

        /// <summary>
        /// Writes a sequence of bytes from 'array' to the buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int WriteBytes(byte[] array, int startIndex, int count)
        {
            Contract.Requires(array != null);
            Contract.Requires(startIndex >= 0);
            Contract.Requires(count >= 0);
            Contract.Requires(array.Length >= (startIndex + count));
            Contract.Requires(count >= this.Available);

            int n;
            for (n = 0; n < count; n++)
                this.data[this.position + n] = array[startIndex + n];

            this.position += n;
            return n;
        }

        /// <summary>
        /// Writes a <see cref="System.Guid"/> to the buffer.
        /// </summary>
        /// <param name="id">The guid to write.</param>
        /// <returns>The number of bytes written, which is always 16 for this operation.</returns>
        public int WriteGuid(Guid id)
        {
            Contract.Ensures(this.Position == Contract.OldValue<int>(this.Position) + 16);
            // Create a sub-buffer to decode the platform-specific result of Guid.ToByteArray()
            DataBuffer db = new DataBuffer(id.ToByteArray(), ByteOrder.System);

            this.WriteInt32(db.ReadInt32());
            this.WriteInt16(db.ReadInt16());
            this.WriteInt16(db.ReadInt16());
            this.WriteBytes(db.ReadBytes(8));

            return 16;
        }

        /// <summary>
        /// Writes a <see cref="System.Version"/> to the buffer. The parts are written in the traditional order (Major, Minor, Build, Revision).
        /// </summary>
        /// <param name="version">The version to write.</param>
        /// <returns>The number of bytes written, which is always 16 for this operation.</returns>
        public int WriteVersion(Version version)
        {
            this.WriteInt32(version.Major);
            this.WriteInt32(version.Minor);
            this.WriteInt32(version.Build);
            this.WriteInt32(version.Revision);

            return 16;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Capacity > 0);
            Contract.Invariant(this.Position >= 0);
            Contract.Invariant(this.Position <= this.Capacity);
        }
        #endregion
    }
}