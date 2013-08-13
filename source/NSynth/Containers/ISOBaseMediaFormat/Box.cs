using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    /// <summary>
    /// Represents an "object-oriented building block defined by a unique type identifier and length".
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Box"/> class.
        /// </summary>
        /// <param name="type"></param>
        public Box(uint type)
        {
            this.Type = type;
        }

        public uint Type
        {
            get;
            set;
        }

        public uint Size
        {
            get;
            set;
        }

        public ulong LargeSize
        {
            get;
            set;
        }

    }

    public class FullBox : Box
    {
        public FullBox(uint boxType, byte version, int flags)
            : base(boxType)
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
            : base(BoxTypes.FileType)
        {


        }

        public FileTypeBox(int majorBrand, int minorVersion)
            : base(BoxTypes.FileType)
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
        public MovieBox()
            : base(BoxTypes.Movie)
        {

        }
    }

    public class MovieHeaderBox : Box
    {
        public MovieHeaderBox()
            : base(BoxTypes.MovieHeader)
        {
        }
    }

    public class ProgressiveDownloadInformationBox : Box
    {
        public ProgressiveDownloadInformationBox()
            : base(0)
        {

        }
    }

    public class TrackBox : Box
    {
        public TrackBox()
            : base(0)
        {

        }
    }
    public class TrackHeaderBox : Box
    {
        public TrackHeaderBox()
            : base(0)
        {

        }

        // Version 1


        public ulong CreationTime
        {
            get;
            set;
        }

        public ulong ModificationTime
        {
            get;
            set;
        }

        public uint TrackId
        {
            get;
            set;
        }

        public ulong Duration
        {
            get;
            set;
        }


        public short Layer
        {
            get;
            set;
        }

        public short AlternateGroup
        {
            get;
            set;
        }

        public short Volume
        {
            get;
            set;
        }

        public ushort Reserved
        {
            get;
            set;
        }
    }

    public class TrackReferenceContainerBox : Box
    {
        public TrackReferenceContainerBox()
            : base(0)
        {

        }
    }

    public class TrackGroupingIndicatorBox : Box
    {
        public TrackGroupingIndicatorBox()
            : base(0)
        {

        }

    }

    public class EditListBox : Box
    {
        public EditListBox()
            : base(0)
        {

        }
    }

    public class MediaInformationBox : Box
    {
        public MediaInformationBox()
            : base(0)
        {
        }
    }

    public class MediaHeaderBox : Box
    {
        public MediaHeaderBox()
            : base(0)
        {
        }
    }
}

