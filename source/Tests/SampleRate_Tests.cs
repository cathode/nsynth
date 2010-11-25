using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NSynth;

namespace Tests
{
    [TestFixture]
    public class SampleRate_Tests
    {
        [Test]
        public void Reduce_Tests()
        {
            SampleRate rate = new SampleRate(96, 4.0);
            SampleRate expected = new SampleRate(24, 1.0);
            SampleRate actual = rate.Reduce();

            Assert.AreEqual(expected, actual);

            rate = new SampleRate(100, 6.0);
            expected = new SampleRate(50, 3.0);
            actual = rate.Reduce();
            Assert.AreEqual(expected, actual);

            rate = new SampleRate(100, 2.5);
            expected = new SampleRate(40, 1);
            actual = rate.Reduce();
            Assert.AreEqual(expected, actual);

            rate = new SampleRate(100, 0.5);
            expected = new SampleRate(100, 0.5);
            actual = rate.Reduce();
            Assert.AreEqual(expected, actual);

            rate = new SampleRate(30000, 1001); // NTSC
            expected = new SampleRate(30000, 1001);
            actual = rate.Reduce();
            Assert.AreEqual(expected, actual);

            rate = new SampleRate(24000, 1001); // Film
            expected = new SampleRate(24000, 1001);
            actual = rate.Reduce();
            Assert.AreEqual(expected, actual);
        }
    }
}
