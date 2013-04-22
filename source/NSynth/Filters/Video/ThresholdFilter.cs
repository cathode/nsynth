using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Filters.Video
{
    public class ThresholdFilter : EffectFilter
    {
        public double Minimum
        {
            get;
            set;
        }

        public double Maximum
        {
            get;
            set;
        }

        protected override void DoProcessing(FilterProcessingContext context, Frame outputFrame)
        {

        }
    }
}
