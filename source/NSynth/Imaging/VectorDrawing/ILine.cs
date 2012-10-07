using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging.VectorDrawing
{
    [ContractClass(typeof(ContractsForILine))]
    public interface ILine
    {
        float Thickness { get; set; }

        Pointf Sample(float t);
    }

    [ContractClassFor(typeof(ILine))]
    internal abstract class ContractsForILine : ILine
    {
        Pointf ILine.Sample(float t)
        {
            Contract.Requires(t >= 0f);
            Contract.Requires(t <= 1f);
            return default(Pointf);
        }

        [ContractInvariantMethod]
        private void _Invariants()
        {

        }

        public float Thickness
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }

}
