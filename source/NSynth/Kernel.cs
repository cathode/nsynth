/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth
{
    /// <summary>
    /// Represents a coordinate-centered symmetrical matrix.
    /// </summary>
    /// <typeparam name="T">The type of items that are contained in the kernel.</typeparam>
    public sealed class Kernel<T>
    {
        #region Fields
        /// <summary>
        /// Holds actual values of the kernel.
        /// </summary>
        private readonly T[,] values;

        /// <summary>
        /// Backing field for the <see cref="RadiusX"/> property.
        /// </summary>
        private readonly int radiusX;

        /// <summary>
        /// Backing field for the <see cref="RadiusY"/> property.
        /// </summary>
        private readonly int radiusY;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Kernel class.
        /// </summary>
        /// <param name="radiusX">The horizontal radius of the kernel, including the origin.</param>
        /// <param name="radiusY">The vertical radius of the kernel, including the origin.</param>
        public Kernel(int radiusX, int radiusY)
        {
            this.values = new T[(radiusX * 2) + 1, (radiusY * 2) + 1];
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        /// <summary>
        /// Initializes a new instance of the Kernel class.
        /// </summary>
        /// <param name="radiusX"></param>
        /// <param name="radiusY"></param>
        /// <param name="defaultValue"></param>
        public Kernel(int radiusX, int radiusY, T defaultValue)
            : this(radiusX, radiusY)
        {
            for (int y = -radiusY; y < radiusY; y++)
                for (int x = -radiusX; x < radiusX; x++)
                    this.values[x, y] = defaultValue;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the width of the Kernel. This is the same as the number of columns in the Kernel.
        /// </summary>
        public int Width
        {
            get
            {
                return (this.radiusX * 2) + 1;
            }
        }

        /// <summary>
        /// Gets the height of the Kernel. This is the same as the number of rows in the Kernel.
        /// </summary>
        public int Height
        {
            get
            {
                return (this.radiusY * 2) + 1;
            }
        }

        /// <summary>
        /// Gets the horizontal radius of the Kernel.
        /// </summary>
        public int RadiusX
        {
            get
            {
                return this.radiusX;
            }
        }

        /// <summary>
        /// Gets the vertical radius of the Kernel.
        /// </summary>
        public int RadiusY
        {
            get
            {
                return this.radiusY;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="Kernel"/> is square.
        /// </summary>
        public bool IsSquare
        {
            get
            {
                return this.Width == this.Height;
            }
        }

        /// <summary>
        /// Gets or sets the value at the center (origin) of the Kernel.
        /// </summary>
        public T OriginValue
        {
            get
            {
                return this[0, 0];
            }
            set
            {
                this[0, 0] = value;
            }
        }
        #endregion
        #region Indexers
        /// <summary>
        /// Gets or sets the value at the specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public T this[int x, int y]
        {
            get
            {
                return this.values[x + this.RadiusX, y + this.RadiusY];
            }
            set
            {
                this.values[x + this.RadiusX, y + this.RadiusY] = value;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Returns an array containing the values in the specified column.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public T[] GetColumn(int column)
        {
            T[] values = new T[(this.radiusY * 2) + 1];
            for (int y = -this.radiusY; y < this.radiusY; y++)
                values[y] = this[column, y];

            return values;
        }

        /// <summary>
        /// Returns an array containing the values in the specified row.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public T[] GetRow(int row)
        {
            T[] values = new T[(this.radiusX * 2) + 1];
            for (int x = -this.radiusX; x < this.radiusX; x++)
                values[x] = this[x, row];

            return values;
        }
        #endregion
    }
}