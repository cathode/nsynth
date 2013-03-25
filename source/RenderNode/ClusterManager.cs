using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderNode
{
    public class ClusterManager
    {

        public ClusterManager()
        {

        }

        public Guid ClusterId
        {
            get;
            set;
        }

        public List<object> Jobs
        {
            get;
            set;
        }
    }
}
