using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yStore.Data.Infrastructure;
using yStore.Data.Repositories;
using yStore.Model.Models;

namespace yStore.Services
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory post);
        void Update(PostCategory post);
        void Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(int pID);
        PostCategory GetById(int id);       
        void SaveChanges();
    }
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;
        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public PostCategory Add(PostCategory postcat)
        {
            return _postCategoryRepository.Add(postcat);
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }
             

        public IEnumerable<PostCategory> GetAllByParentId(int id)
        {
            return _postCategoryRepository.GetMulti(x=>x.ParentID == id  && x.Status == true);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postcat)
        {
            _postCategoryRepository.Update(postcat);
        }
    }
}
