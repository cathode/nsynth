using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderNode
{

    public enum DistributionFlags
    {
        None = 0x00,
        ReadOnly = 0x01,
        Master = 0x02,
    }

    /// <summary>
    /// Represents a datastore that is distributed and synchronized across multiple nodes in a cluster.
    /// </summary>
    public class DistributedDatastore
    {
        #region Properties
        /// <summary>
        /// Gets or sets the unique id of the distributed datastore.
        /// </summary>
        public Guid DatastoreId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating the total known copies of the datastore across the cluster (including the local copy).
        /// </summary>
        public int KnownReplicationCount
        {
            get
            {
                return 1;
            }
        }
        #endregion
        #region Events

        #endregion
        #region Methods
        /// <summary>
        /// Stores a record.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Store(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public object Retrieve(string key)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
