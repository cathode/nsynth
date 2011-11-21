// -----------------------------------------------------------------------
// <copyright file="IFrameSource.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace NSynth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IFrameSource
    {
        long FrameCount
        {
            get;
        }

        Frame Render(long index);
    }
}
