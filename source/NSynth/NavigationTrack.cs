// -----------------------------------------------------------------------
// <copyright file="NavigationTrack.cs" company="">
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
    public class NavigationTrack : Track
    {
        public override TrackKind Kind
        {
            get
            {
                return TrackKind.Navigation;
            }
        }

        protected override Track CreateDeepClone()
        {
            return new NavigationTrack();
        }
    }
}
