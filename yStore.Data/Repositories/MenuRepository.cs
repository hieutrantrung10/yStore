using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yStore.Data.Infrastructure;
using yStore.Model.Models;

namespace yStore.Data.Repositories
{
    public interface IMenuRepository
    {

    }
    public class MenuRepository : RepositoryBase<Menu>,IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) 
            : base(dbFactory)
        {

        }
    }
}
