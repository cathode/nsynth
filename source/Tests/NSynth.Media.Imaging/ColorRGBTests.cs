/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSynth.Imaging;

namespace Tests.NSynth.Imaging
{
    /// <summary>
    /// Unit tests for NSynth.Imaging namespace.
    /// </summary>
    [TestFixture]
    public class ColorRGBTests
    {
        [Test]
        public void CompressTest()
        {
            ColorRGB actual = new ColorRGB(2.0f, 1.0f, 0.5f, 1.0f);
            ColorRGB expected = new ColorRGB(1.0f, 0.5f, 0.25f, 0.5f);

            actual.Normalize();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetCompressedTest()
        {
            ColorRGB input = new ColorRGB(2.0f, 1.0f, 0.5f, 1.0f);
            ColorRGB expected = new ColorRGB(1.0f, 0.5f, 0.25f, 0.5f);

            ColorRGB actual = input.GetCompressed();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetCompressedShouldEqualCompress()
        {
            ColorRGB input = new ColorRGB(1.5f, 0.4f, -51.5f, 0.0f);

            ColorRGB compress = input.GetCompressed();
            input.Normalize();

            bool expected = true;
            bool actual = compress == input;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClampTest()
        {
            ColorRGB actual = new ColorRGB(2.0f, -3.0f, 0.5f, 1.0f);
            ColorRGB expected = new ColorRGB(1.0f, 0.0f, 0.5f, 1.0f);

            actual.Clamp();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetClampedTest()
        {
            ColorRGB input = new ColorRGB(2.0f, -3.0f, 0.5f, 1.0f);
            ColorRGB expected = new ColorRGB(1.0f, 0.0f, 0.5f, 1.0f);

            ColorRGB actual = input.GetClamped();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetClampedShouldEqualClamp()
        {
            ColorRGB input = new ColorRGB(1.5f, 0.4f, -51.5f, 0.0f);

            ColorRGB clamp = input.GetClamped();
            input.Clamp();

            bool expected = true;
            bool actual = clamp == input;

            Assert.AreEqual(expected, actual);
        }
    }
}
