/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging
{
    /// <summary>
    /// Provides a output filter that allows frames to be outputted to image files.
    /// </summary>
    public abstract class ImageOutputFilter : OutputFilter
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="ImageOutputFilter.Path"/> property.
        /// </summary>
        private string path;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageOutputFilter"/> class.
        /// </summary>
        /// <param name="path"></param>
        protected ImageOutputFilter(string path)
        {
            Contract.Requires(path != null);
            Contract.Requires(path != string.Empty);

            this.path = path;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the path where frames are outputted.
        /// </summary>
        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value;
            }
        }
        #endregion
        #region Methods
        protected abstract ImageEncoder GetEncoder(Stream bitstream);
        #endregion
    }
}
