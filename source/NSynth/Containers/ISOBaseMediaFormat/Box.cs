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

        public Box(uint type, Guid userType)
        {
            this.Type = type;
            this.UserType = userType;
        }
        public uint Size
        {
            get;
            set;
        }


        public uint Type
        {
            get;
            set;
        }

        public ulong LargeSize
        {
            get;
            set;
        }
        public Guid UserType { get; set; }
    }

    public sealed class BoxTypeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxTypeAttribute"/> class.
        /// </summary>
        /// <param name="type"></param>
        public BoxTypeAttribute(uint type)
        {
            this.Type = type;
        }

        public uint Type { get; private set; }
    }

    public class FullBox : Box
    {
        public FullBox(uint boxType, byte version, int flags = 0)
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

    //[BoxType(BoxTypes.Hint)]
    public class HintBox : Box
    {
        public HintBox()
            : base(BoxTypes.HintMediaHeader)
        {

        }
    }

    [BoxType(BoxTypes.FileType)]
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
    [BoxType(BoxTypes.Movie)]
    public class MovieBox : Box
    {
        public MovieBox()
            : base(BoxTypes.Movie)
        {

        }
    }
    [BoxType(BoxTypes.MovieHeader)]
    public class MovieHeaderBox : Box
    {
        public MovieHeaderBox()
            : base(BoxTypes.MovieHeader)
        {
        }
    }

    [BoxType(BoxTypes.ProgressiveDownloadInformation)]
    public class ProgressiveDownloadInformationBox : FullBox
    {
        public ProgressiveDownloadInformationBox()
            : base(BoxTypes.ProgressiveDownloadInformation, 0)
        {

        }

        public ProgressiveDownloadInfoChunk[] Data
        {
            get;
            set;
        }

        public struct ProgressiveDownloadInfoChunk
        {
            public uint Rate;
            public uint InitialDelay;
        }
    }

    [BoxType(BoxTypes.Track)]
    public class TrackBox : Box
    {
        public TrackBox()
            : base(0)
        {

        }
    }

    [BoxType(BoxTypes.TrackHeader)]
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

    //[BoxType(BoxTypes.TrackReference
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

    [BoxType(BoxTypes.EditList)]
    public class EditListBox : Box
    {
        public EditListBox()
            : base(BoxTypes.EditList)
        {

        }
    }

    [BoxType(BoxTypes.EditListContainer)]
    public class EditListContainerBox : Box
    {
        public EditListContainerBox() : base(BoxTypes.EditListContainer) { }

    }

    //[BoxType(BoxTypes.MediaInformation
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

