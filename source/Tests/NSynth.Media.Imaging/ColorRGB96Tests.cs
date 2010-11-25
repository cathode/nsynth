using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSynth.Imaging;

namespace Tests.NSynth.Imaging
{
    [TestFixture]
    public class ColorRGB96Tests
    {
        [Test]
        public void CompressTest()
        {
            ColorRGB96 actual = new ColorRGB96(2.0f, 1.0f, 0.5f);
            ColorRGB96 expected = new ColorRGB96(1.0f, 0.5f, 0.25f);

            actual.Compress();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetCompressedTest()
        {
            ColorRGB96 input = new ColorRGB96(2.0f, 1.0f, 0.5f);
            ColorRGB96 expected = new ColorRGB96(1.0f, 0.5f, 0.25f);

            ColorRGB96 actual = input.GetCompressed();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetCompressedShouldEqualCompress()
        {
            ColorRGB96 input = new ColorRGB96(1.5f, 0.4f, -51.5f);

            ColorRGB96 compress = input.GetCompressed();
            input.Compress();

            bool expected = true;
            bool actual = compress == input;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClampTest()
        {
            ColorRGB96 actual = new ColorRGB96(2.0f, -3.0f, 0.5f);
            ColorRGB96 expected = new ColorRGB96(1.0f, 0.0f, 0.5f);

            actual.Clamp();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetClampedTest()
        {
            ColorRGB96 input = new ColorRGB96(2.0f, -3.0f, 0.5f);
            ColorRGB96 expected = new ColorRGB96(1.0f, 0.0f, 0.5f);

            ColorRGB96 actual = input.GetClamped();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetClampedShouldEqualClamp()
        {
            ColorRGB96 input = new ColorRGB96(1.5f, 0.4f, -51.5f);

            ColorRGB96 clamp = input.GetClamped();
            input.Clamp();

            bool expected = true;
            bool actual = clamp == input;

            Assert.AreEqual(expected, actual);
        }
    }
}
