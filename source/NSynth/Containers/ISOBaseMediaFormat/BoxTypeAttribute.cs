using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
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
}
