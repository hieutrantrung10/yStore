using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yStore.Data.Infrastructure;
using yStore.Model.Models;

namespace yStore.Data.Repositories
{
    public interface IPostRepository
    {

    }
    public class PostRepository : RepositoryBase<Post>
    {
        public PostRepository (IDbFactory dbFactory) 
            : base(dbFactory)
        {

        }
    }
}
