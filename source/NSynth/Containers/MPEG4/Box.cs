using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.MPEG4
{
    /// <summary>
    /// Represents an "object-oriented building block defined by a unique type identifier and length".
    /// </summary>
    public class Box
    {

        public Box(int type)
        {
            this.Type = type;
        }

        public int Type
        {
            get;
            set;
        }

        public int Size
        {
            get;
            set;
        }



    }

    public class FullBox : Box
    {
        public FullBox(int boxType, byte version, int flags)
        {
            this.Version = version;
            this.Flags = flags;
        }

        public byte Version
        {
            get;
            set;
        }

        public int Flags
        {
            get;
            set;
        }
    }

    public class FileTypeBox : Box
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileTypeBox"/> class.
        /// </summary>
        public FileTypeBox()
        {


        }

        public FileTypeBox(int majorBrand, int minorVersion)
        {

        }
        public int MajorBrand
        {
            get;
            set;
        }

        public int MinorVersion
        {
            get;
            set;
        }

        public int[] CompatibleBrands
        {
            get;
            set;
        }
    }

    public class MovieBox : Box
    {

    }

    public class MovieHeaderBox : Box
    {

    }

    public class ProgressiveDownloadInformationBox : Box
    {

    }

    public class TrackBox : Box
    {

    }
    public class TrackHeaderBox : Box
    {

    }

    public class TrackReferenceContainerBox : Box
    {

    }

    public class TrackGroupingIndicatorBox : Box
    {

    }

    public class EditListBox : Box
    {
    }

    public class MediaInformationBox : Box
    {

    }

    public class MediaHeaderBox : Box
    {
    }
}

