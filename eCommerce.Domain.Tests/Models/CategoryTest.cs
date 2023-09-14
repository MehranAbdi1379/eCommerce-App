using eCommerce.Domain.Exceptions;
using eCommerce.Domain.Models;
using eCommerce.Repository.Main;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Tests.Models
{
    [TestClass]
    public class CategoryTest
    {
        private readonly Mock<ICategoryRepository> categoryRepositoryMock = new Mock<ICategoryRepository>();
        public CategoryTest()
        {
            categoryRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
            categoryRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(new Category("title"));
        }
        [TestMethod]
        public void SetTitle_Retrieve()
        {
            var category = new Category("title");
            category.SetTitle("Title");
            Assert.AreEqual("Title", category.Title);
        }

        [TestMethod]
        public void SetTitle_TitleNull_ThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Category(""));
        }

        [TestMethod]
        public void SetIndex_Retrieve()
        {
            Assert.AreEqual(0, new Category("title").Index);
        }

        [TestMethod]
        public void SetParentId_Retrieve()
        {
            var category = new Category("title");
            var parentId = new Guid();
            category.SetParentCategoryId(parentId, categoryRepositoryMock.Object);
            Assert.AreEqual(parentId, category.ParentCategoryId);
        }

        [TestMethod]
        public void SetParentId_CategoryNotExist_ThrowException()
        {
            var category = new Category("title");
            categoryRepositoryMock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<CategoryNotExistException>(() => category.SetParentCategoryId(new Guid() , categoryRepositoryMock.Object));
        }

        [TestMethod]
        public void SetIndex_SetAccordingToParentId()
        {
            var category = new Category("title");
            category.SetParentCategoryId(new Guid(), categoryRepositoryMock.Object);
            Assert.AreEqual(1 , category.Index);
        }
    }
}
