/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a layer within an image.
    /// </summary>
    public abstract class Layer
    {
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Image"/> that the current layer belongs to.
        /// </summary>
        public Image Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the opacity of the contents of the current layer.
        /// </summary>
        public float Opacity
        {
            get;
            set;
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
