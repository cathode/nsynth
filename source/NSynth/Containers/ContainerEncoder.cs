using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers
{
    public abstract class ContainerEncoder : MediaEncoder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clip"></param>
        /// <returns></returns>
        public bool CanContain(Clip clip)
        {
            return false;
        }
    }
}
