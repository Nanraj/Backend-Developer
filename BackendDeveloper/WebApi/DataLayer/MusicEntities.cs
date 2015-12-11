using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace DataLayer
{
    public partial class MusicEntities 
    {
        public MusicEntities(string connectionString)
            : base(connectionString)
        { 
        
        }

        public void SetCommandTimeOut(int timeout)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = timeout;
        }
    }
}
