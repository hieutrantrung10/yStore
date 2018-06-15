using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yStore.Data.Infrastructure;
using yStore.Model.Models;

namespace yStore.Data.Repositories
{
    public interface IPageRepository
    {

    }
    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
