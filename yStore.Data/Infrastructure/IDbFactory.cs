using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yStore.Data.Infrastructure
{
    public interface IDbFactory:IDisposable
    {
        yStoreDbContext Init();
    }
}
