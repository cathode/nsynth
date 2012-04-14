/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Imaging
{
    /// <summary>
    /// Defines an interface for color types. 
    /// </summary>
    public interface IColor
    {
        #region Properties
        /// <summary>
        /// Gets or sets the value of the red color component as a linear floating point value between 0.0 (no saturation) and 1.0 (full saturation).
        /// </summary>
        float Red
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the value of the green color component as a linear floating point value between 0.0 (no saturation) and 1.0 (full saturation).
        /// </summary>
        float Green
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of the blue color component as a linear floating point value between 0.0 (no saturation) and 1.0 (full saturation).
        /// </summary>
        float Blue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of the alpha (opacity) component as a linear floating point value between 0.0 (fully transparent) and 1.0 (fully opaque).
        /// </summary>
        float Alpha
        {
            get;
            set;
        }
        #endregion
    }
}