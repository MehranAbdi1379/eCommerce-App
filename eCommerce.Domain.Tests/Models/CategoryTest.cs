using eCommerce.Domain.Exceptions.Category;
using eCommerce.Domain.Models;
using eCommerce.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Tests.Models
{
    [TestClass]
    public class CategoryTest
    {
        private Mock<ICategoryRepository> categoryRepository = new Mock<ICategoryRepository>();
        private Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
        public CategoryTest()
        {
            categoryRepository.Setup(repo => repo.IsExist(It.IsAny<Guid>())).Returns(true);
            categoryRepository.Setup(repo => repo.GetNeighboorCategories(It.IsAny<Guid>())).Returns(new List<Category>());
            categoryRepository.Setup(repo => repo.GetRootCategories()).Returns(new List<Category>());

            productRepository.Setup(repo => repo.CategoryHasAnyProduct(It.IsAny<Guid>())).Returns(false);
        }

        [TestMethod]
        public void Properties_Retrieve()
        {
            var category = CreateValidCategory();
            var parentCategoryId = Guid.NewGuid();
            category.SetParentCategoryId(parentCategoryId, categoryRepository.Object,productRepository.Object);
            Assert.IsNotNull(category);
            Assert.AreEqual("Title", category.Title);
            Assert.AreEqual(parentCategoryId, category.ParentCategoryId);
        }

        [TestMethod]
        public void SetTitle_TitleNotValid_ThrowException()
        {
            var category = CreateValidCategory();
            Assert.ThrowsException<ArgumentNullException>(() => category.SetTitle("", categoryRepository.Object));
        }

        [TestMethod]
        public void SetTitle_TitleNeighboorExist_ThrowException()
        {
            var category = CreateValidCategory();
            List<Category> categories = new List<Category> { new Category("Title", categoryRepository.Object) };
            categoryRepository.Setup(repo => repo.GetRootCategories()).Returns(categories);
            Assert.ThrowsException<CategoryNeighboorTitleExistsException>(() => category.SetTitle("Title", categoryRepository.Object));
        }

        [TestMethod]
        public void SetParentCategoryId_OwnId_ThrowException()
        {
            var category = CreateValidCategory();
            Assert.ThrowsException<CategoryOwnParentCategoryExcpetion>(() => category.SetParentCategoryId(category.Id, categoryRepository.Object,productRepository.Object));
        }

        [TestMethod]
        public void SetParentCategoryId_NeighboorTitleExist_ThrowException()
        {
            var category = CreateValidCategory();
            List<Category> categories = new List<Category> { new Category("Title", categoryRepository.Object) };
            categoryRepository.Setup(repo => repo.GetNeighboorCategories(It.IsAny<Guid>())).Returns(categories);
            Assert.ThrowsException<CategoryNeighboorTitleExistsException>(() => category.SetParentCategoryId(Guid.NewGuid(), categoryRepository.Object, productRepository.Object));
        }

        [TestMethod]
        public void SetParentCategoryId_NotExist_throwException()
        {
            var category = CreateValidCategory();
            categoryRepository.Setup(repo => repo.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<CategoryNotExistException>(() => category.SetParentCategoryId(Guid.NewGuid(), categoryRepository.Object, productRepository.Object));
        }

        [TestMethod]
        public void SetParentCategoryId_AlreadyHasProduct_ThrowException()
        {
            var category = CreateValidCategory();
            productRepository.Setup(repo => repo.CategoryHasAnyProduct(It.IsAny<Guid>())).Returns(true);
            Assert.ThrowsException<CategoryHasProductException>(() => category.SetParentCategoryId(Guid.NewGuid(), categoryRepository.Object, productRepository.Object));
        }

        [TestMethod]
        public void RemoveParentCategoryId_TitleExist_ThrowException()
        {
            var category = CreateValidCategory();
            category.SetParentCategoryId(Guid.NewGuid(),categoryRepository.Object, productRepository.Object);
            List<Category> categories = new List<Category> { new Category("Title", categoryRepository.Object) };
            categoryRepository.Setup(repo => repo.GetRootCategories()).Returns(categories);
            Assert.ThrowsException<CategoryNeighboorTitleExistsException>(() => category.RemoveParentCategoryId(categoryRepository.Object));
        }


        private Category CreateValidCategory()
        {
            return new Category("Title", categoryRepository.Object);
        }
    }
}
