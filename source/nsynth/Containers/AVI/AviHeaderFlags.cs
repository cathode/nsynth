using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.AVI
{
    [Flags]
    public enum AviHeaderFlags : uint
    {
        HasIndex, //AVIF_HASINDEX
        MustUseIndex, //AVIF_MUSTUSEINDEX
        IsInterleaved, //AVIF_ISINTERLEAVED
        WasCaptureFile, //AVIF_WASCAPTUREFILE
        Copyrighted,    //AVIF_COPYRIGHTED
        TrustCKType     //AVIF_TRUSTCKTYPE
    }
}
