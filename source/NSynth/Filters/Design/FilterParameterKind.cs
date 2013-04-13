/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/

namespace NSynth.Filters
{
    /// <summary>
    /// Represents parameter types that can be designed.
    /// </summary>
    public enum FilterParameterKind
    {
        String = 0x0,
        Integer,
        Float,
        Filter,
        Size,
        Rectangle,
        Enumeration,
    }
}
