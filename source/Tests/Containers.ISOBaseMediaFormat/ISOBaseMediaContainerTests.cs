using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSynth.Containers.ISOBaseMediaFormat;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    [TestFixture]
    public class ISOBaseMediaContainerTests
    {
        [Test]
        public void TestDecoding()
        {
            var iso = new ISOBaseMediaContainer("");

            iso.ExtractBoxes("");
        }
    }
}
