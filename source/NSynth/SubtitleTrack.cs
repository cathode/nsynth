// -----------------------------------------------------------------------
// <copyright file="SubtitleTrack.cs" company="">
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
    public class SubtitleTrack : Track
    {
        public override TrackKind Kind
        {
            get
            {
                return TrackKind.Subtitle;
            }
        }

        protected override Track CreateDeepClone()
        {
            return new SubtitleTrack();
        }
    }
}
