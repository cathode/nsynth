/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a layer within an image.
    /// </summary>
    public class Layer
    {
        #region Fields
        private readonly Image owner;
        private readonly IBitmap content;
        private readonly IBitmap mask;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Layer"/> class.
        /// </summary>
        /// <param name="owner"></param>
        internal Layer(Image owner)
        {
            Contract.Requires(owner != null);

            this.owner = owner;
            this.content = owner.Format.CreateBitmap(owner.Size);
            this.mask = owner.Format.CreateBitmap(owner.Size);
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Image"/> that the current layer belongs to.
        /// </summary>
        public Image Owner
        {
            get
            {
                return this.owner;
            }
        }

        public IBitmap Content
        {
            get
            {
                return this.content;
            }
        }

        /// <summary>
        /// Gets the <see cref="IBitmap"/> that will be used as the blend mask.
        /// </summary>
        public IBitmap BlendMask
        {
            get
            {
                return this.mask;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="CombineMode"/> that determines how the current layer is blended with the layer below it.
        /// </summary>
        public CombineMode Mode
        {
            get;
            set;
        }
        #endregion
    }
}
