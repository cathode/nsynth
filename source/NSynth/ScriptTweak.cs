/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;

using System.Text;

namespace NSynth
{
    /// <summary>
    /// Represents a script-wide user-configurable value to which action parameters can be "tweaked with".
    /// </summary>
    public sealed class ScriptTweak
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptTweak"/> class.
        /// </summary>
        /// <param name="name"></param>
        public ScriptTweak(string name)
        {
            if (!ScriptTweak.IsValidName(name))
                throw new ArgumentException("The name parameter contained invalid characters.", "name");

            this.name = name;
        }
        #endregion
        #region Fields
        private readonly string name;
        private string value;
        #endregion
        #region Methods
        public static bool IsValidName(string name)
        {
            if (name == null)
                return false;

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] < 'a' || name[i] > 'Z')
                    return false;
            }

            return true;
        }
        #endregion
        #region Properties
        public string Name
        {
            get
            {
                return this.name;
            }
        }
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
    }
}
