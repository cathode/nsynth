// -----------------------------------------------------------------------
// <copyright file="IgnoreAlphaFilter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace NSynth.Filters.Video
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class IgnoreAlphaFilter : EffectFilter
    {
        public override Frame Render(long frameIndex)
        {
            var frame = this.InputFrames.GetValue(frameIndex);
            var result = new Frame();
            

            return frame;
        }
    }
}
