using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yStore.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        yStoreDbContext dbContext;
        public yStoreDbContext Init()
        {
            return dbContext ?? (dbContext = new yStoreDbContext());
        }
        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
