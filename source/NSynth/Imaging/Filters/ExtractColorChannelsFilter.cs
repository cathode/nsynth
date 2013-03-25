using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging.Filters
{
    /// <summary>
    /// Extracts color channels from the source bitmap and returns each channel as a separate color plane.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExtractColorChannelsFilter<T> : ImageFilter<T> where T : IColor
    {
        public ColorChannels Channels
        {
            get;
            set;
        }

        public new IBitmap[] Apply(Bitmap<T> source)
        {
            List<IBitmap> result = new List<IBitmap>();

            foreach (var channel in from v in (IEnumerable<ColorChannels>)Enum.GetValues(typeof(ColorChannels))
                                    where source.Format.Channels.HasFlag(v) && this.Channels.HasFlag(v)
                                    select v)
            {

            }

            return result.ToArray();
        }
    }
}
