using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yStore.Data.Infrastructure;
using yStore.Model.Models;
using System.Linq;

namespace yStore.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Post> GetAllByCategoryId(int cID);
    }
    public class PostRepository : RepositoryBase<Post>,IPostRepository
    {
        public PostRepository (IDbFactory dbFactory) 
            : base(dbFactory)
        {

        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Posts
                        join t in DbContext.PostTags
                        on p.ID equals t.PostID
                        where t.TagID == tag
                        && p.Status
                        orderby p.CreatedDate descending
                        select p;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize);
            return query;
        }

        
    }
}
