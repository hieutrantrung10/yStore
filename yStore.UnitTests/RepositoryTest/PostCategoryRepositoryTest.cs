using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yStore.Data.Infrastructure;
using yStore.Data.Repositories;
using yStore.Model.Models;

namespace yStore.UnitTests.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test Category 1";
            category.Alias = "Test-category-1";
            category.DisplayOrder = 1;

            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();

            Assert.AreEqual(1, result.ID);
            Assert.IsNotNull(result.ID);
        }
    }
}
