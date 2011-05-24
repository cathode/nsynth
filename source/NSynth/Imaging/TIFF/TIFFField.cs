/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth.Imaging.TIFF
{
    /// <summary>
    /// Represents an entry in a TIFF Image File Directory.
    /// </summary>
    public abstract class TIFFField
    {
        #region Fields

        /// <summary>
        /// Backing field for <see cref="NSynth.Imaging.TIFFField.Count"/>.
        /// </summary>
        private int count;

        /// <summary>
        /// Backing field for <see cref="NSynth.Imaging.TIFFField.ValueOffset"/>.
        /// </summary>
        private int valueOffset;

        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the number of values in the current TIFF Field.
        /// </summary>
        /// <remarks>
        /// Note that Count is not the total number of bytes. For example, a TIFF field containing a single 16-bit word (<see cref="NSynth.Imaging.TIFFFieldType.Short"/>)
        /// has a Count of 1; not 2, because the field only contains 1 element (even though that element is 2-bytes in length).
        /// </remarks>
        public int Count
        {
            get
            {
                return this.count;
            }
            protected set
            {
                this.count = value;
            }
        }

        /// <summary>
        /// Gets the type of the current TIFF field.
        /// </summary>
        public abstract TIFFFieldType FieldType
        {
            get;
        }

        /// <summary>
        /// Gets the tag that identifies the field.
        /// </summary>
        public abstract TIFFTag Tag
        {
            get;
        }

        /// <summary>
        /// Gets the zero-based offset within the file that contains the data for the field,
        /// or if the value is 4 bytes or smaller, contains the value itself.
        /// </summary>
        public int ValueOffset
        {
            get
            {
                return this.valueOffset;
            }
            internal set
            {
                this.valueOffset = value;
            }
        }

        #endregion
        #region Methods

        /// <summary>
        /// Reads all field elements of a multi-value <see cref="TIFFField"/> into the specified buffer.
        /// </summary>
        /// <param name="buffer">The buffer to read field element data into.</param>
        /// <returns>The number of field elements read.</returns>
        public long ReadFieldValue(byte[] buffer)
        {
            return this.ReadFieldValue(buffer, 0, this.Count);
        }

        /// <summary>
        /// Reads a single field element of a multi-value <see cref="TIFFField"/> into the specified buffer.
        /// </summary>
        /// <param name="buffer">The buffer to read field element data into.</param>
        /// <param name="index">The zero-based index of the field element to read.</param>
        /// <remarks>
        /// This method only reads a single value and so does not return the number of elements read as its' overloads do.
        /// </remarks>
        public void ReadFieldValue(byte[] buffer, long index)
        {
            this.ReadFieldValue(buffer, index, 1);
        }

        /// <summary>
        /// Reads a range of elements of a multi-value <see cref="TIFFField"/> into the specified buffer.
        /// </summary>
        /// <param name="buffer">The buffer to read field element data into.</param>
        /// <param name="startIndex">The first field element to start reading.</param>
        /// <param name="count">The number of field elements to read.</param>
        /// <returns>The number of field elements read.</returns>
        public abstract long ReadFieldValue(byte[] buffer, long startIndex, long count);

        /// <summary>
        /// Writes all elements of a multi-value <see cref="TIFFField"/> from the specified buffer.
        /// </summary>
        /// <param name="buffer">The bytes to be written.</param>
        /// <returns>The number of field elements written.</returns>
        public long WriteFieldValue(byte[] buffer)
        {
            return this.WriteFieldValue(buffer, 0, this.Count);
        }

        /// <summary>
        /// Writes a single element of a multi-value <see cref="TIFFField"/> from the specified buffer.
        /// </summary>
        /// <param name="buffer">The bytes to be written.</param>
        /// <param name="index">The zero-based index of the field element to write.</param>
        /// <remarks>
        /// This method only writes a single field element and so does not return the number of elements written as its' overloads do.
        /// </remarks>
        public void WriteFieldValue(byte[] buffer, long index)
        {
            this.WriteFieldValue(buffer, index, 1);
        }

        /// <summary>
        /// Writes a range of elements of a multi-value <see cref="TIFFField"/> from the specified buffer.
        /// </summary>
        /// <param name="buffer">The bytes to be written.</param>
        /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
        /// <param name="count">The number of field elements to write.</param>
        /// <returns>The number of field elements written.</returns>
        public abstract long WriteFieldValue(byte[] buffer, long startIndex, long count);

        #endregion
        #region Types

        /// <summary>
        /// Represents the Artist field of a TIFF bitstream.
        /// </summary>
        public sealed class ArtistField : TIFFField
        {
            #region Fields

            /// <summary>
            /// Backing field for the <see cref="ArtistField.Value"/> property.
            /// </summary>
            private string value;

            #endregion
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Ascii;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.Artist;
                }
            }

            /// <summary>
            /// Gets or sets the artist name or description.
            /// </summary>
            public string Value
            {
                get
                {
                    return this.value;
                }
                set
                {
                    this.value = value;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new System.NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new System.NotImplementedException();
            }

            #endregion
        }

        /// <summary>
        /// Represents the number of bits per component of a color value.
        /// </summary>
        public sealed class BitsPerSampleField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.BitsPerSample;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class CellLengthField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.CellLength;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class CellWidthField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.CellWidth;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class ColorMapField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.ColorMap;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class CompressionField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.Compression;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class CopyrightField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Ascii;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.Copyright;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class DateTimeField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Ascii;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.DateTime;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class ExtraSamplesField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.ExtraSamples;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class FillOrderField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.FillOrder;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class FreeByteCountsField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Long;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.FreeByteCounts;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class FreeOffsetsField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Long;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.FreeOffsets;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class GrayResponseCurveField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.GrayResponseCurve;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class GrayResponseUnitField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.GrayResponseUnit;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class HostComputerField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Ascii;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.HostComputer;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class ImageDescriptionField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Ascii;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.ImageDescription;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class ImageLengthField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Long;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.ImageLength;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class ImageWidthField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Long;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.ImageWidth;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class MakeField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Ascii;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.Make;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class MaxSampleValueField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.MaxSampleValue;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class MinSampleValueField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.MinSampleValue;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class ModelField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Ascii;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.Model;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class NewSubfileTypeField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Long;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.NewSubfileType;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class OrientationField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    return TIFFFieldType.Short;
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    return TIFFTag.Orientation;
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class PhotometricInterpretationField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class PlanarConfigurationField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class ResolutionUnitField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class RowsPerStripField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class SamplesPerPixelField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class SoftwareField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class StripByteCountsField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class StripOffsetsField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class SubfileTypeField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class ThreshholdingField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class XResolutionField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public sealed class YResolutionField : TIFFField
        {
            #region Properties

            /// <summary>
            /// Gets the <see cref="TIFFFieldType"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFFieldType FieldType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="TIFFTag"/> of the current <see cref="TIFFField"/>.
            /// </summary>
            public override TIFFTag Tag
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
            #region Methods

            /// <summary>
            /// Overridden. <see cref="TIFFField.ReadFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The buffer to read field element data into.</param>
            /// <param name="startIndex">The first field element to start reading.</param>
            /// <param name="count">The number of field elements to read.</param>
            /// <returns>The number of field elements read.</returns>
            public override long ReadFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Overridden. See <see cref="TIFFField.WriteFieldValue(byte[],long,long)"/> for information about this method.
            /// </summary>
            /// <param name="buffer">The bytes to be written.</param>
            /// <param name="startIndex">The zero-based index of the field element to start writing.</param>
            /// <param name="count">The number of field elements to write.</param>
            /// <returns>The number of field elements written.</returns>
            public override long WriteFieldValue(byte[] buffer, long startIndex, long count)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        #endregion
    }
}