using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    /// <summary>
    /// Provides a container box for a single track within a presentation. Typically any given presentation is made up of multiple such tracks.
    /// </summary>
    [BoxType(BoxTypes.Track)]
    public class TrackBox : Box
    {
        public TrackBox()
            : base(BoxTypes.Track)
        {

        }
    }
}
