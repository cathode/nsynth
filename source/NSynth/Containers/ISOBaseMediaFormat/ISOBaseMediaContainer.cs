/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    /// <summary>
    /// Provides an implementation of the ISO Base Media Format
    /// </summary>
    public class ISOBaseMediaContainer
    {


        /// <summary>
        /// Globally registered types of iso file format data boxes.
        /// </summary>
        private static readonly Dictionary<uint, Type> _globalReg = new Dictionary<uint, Type>();


        private string path;

        static ISOBaseMediaContainer()
        {
            // Basic boxes
            GlobalRegister<FileTypeBox>();
            GlobalRegister<HintBox>();
            GlobalRegister<TrackBox>();
            GlobalRegister<TrackHeaderBox>();
            
            
            GlobalRegister<EditListBox>();
            GlobalRegister<TrackGroupingIndicatorBox>();
            GlobalRegister<TrackReferenceBox>();
            GlobalRegister<EditListContainerBox>();

            // Media
            GlobalRegister<MediaBox>();
            GlobalRegister<MediaHeaderBox>();
            GlobalRegister<MediaInformationBox>();

            // Video
            GlobalRegister<MovieBox>();
            GlobalRegister<MovieHeaderBox>();

            // Audio
        }

        public ISOBaseMediaContainer(string path)
        {
            this.path = path;
        }

        public void ExtractBoxes(string outputPath)
        {
            using (var inStream = File.OpenRead(this.path))
            {
                using (var outStream = File.Open(outputPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    var rbuf = new byte[4096];
                    int position = 0;




                }
            }
        }

        public static void GlobalRegister<TBox>() where TBox : Box
        {
            var t = typeof(TBox);
            var attr = t.GetCustomAttribute<BoxTypeAttribute>(false);

            if (attr != null)
            {
                uint boxType = attr.Type;

                if (!ISOBaseMediaContainer._globalReg.ContainsKey(boxType) && !ISOBaseMediaContainer._globalReg.ContainsValue(t))
                    ISOBaseMediaContainer._globalReg.Add(boxType, t);
            }
        }

        public static void GlobalUnregister(uint boxType)
        {
            _globalReg.Remove(boxType);
        }

        public static Box Create(uint boxType)
        {
            if (ISOBaseMediaContainer._globalReg.ContainsKey(boxType))
            {
                var t = ISOBaseMediaContainer._globalReg[boxType];
                if (t != null)
                    return Activator.CreateInstance(_globalReg[boxType]) as Box;
            }

            throw new NotImplementedException();
        }

        public static TBox Create<TBox>() where TBox : Box
        {
            var t = typeof(TBox);
            var attr = t.GetCustomAttribute<BoxTypeAttribute>(false);

            if (attr != null)
            {
                uint boxType = attr.Type;

                return Activator.CreateInstance(_globalReg[boxType]) as TBox;
            }
            else
                throw new NotImplementedException();
        }
    }
}
