/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;
using System.IO;

namespace NSynth.Filters.Internal
{
    /// <summary>
    /// Provides an action that saves frames from it's input to a cache so that
    /// each frame from it's input is only processed once.
    /// </summary>
    /// <remarks>
    /// The Path parameter should contain a format placeholder in which the
    /// unique ID of the cache action is inserted. This prevents conflicts when
    /// multiple cache actions are in use. The second format placeholder is
    /// replaced by the index of the frame being cached. In almost all cases
    /// the default value should be used, as it uses the current user's local
    /// temporary folder. Only change this if the cache files need to be stored
    /// on a different drive, for example a second hard disk or a ramdisk.
    /// </remarks>
    public sealed class CacheFilter : ProcessFilterBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheFilter"/> class.
        /// </summary>
        public CacheFilter()
        {
            this.uniqueId = Guid.NewGuid();
            this.path = CacheFilter.DefaultCachePath;
        }
        #endregion
        #region Fields
        private string path;
        private Guid uniqueId;
        public const string DefaultCachePath = @"%TEMP%\NSynth\Cache\{0}\{1}.framecache";
        #endregion
        #region Methods
        protected override Frame RenderFrame(long index)
        {
            if (this.path == null || this.path.Length < 1)
                return null;

            string framePath = string.Format(this.path, this.uniqueId, index);
            string dirPath = Path.GetDirectoryName(framePath);
            
            if (dirPath.Length > 0)
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);

            throw new NotImplementedException();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the path string to save and load cached frames from.
        /// </summary>
        public string CachePath
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

        public override Clip GetClip()
        {
            throw new NotImplementedException();
        }
    }
}
