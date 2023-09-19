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
        private Mock<ICategoryRepository> mockRepository;

        [TestInitialize]
        public void Initialize()
        {
            mockRepository = new Mock<ICategoryRepository>();
        }

        [TestMethod]
        public void Constructor_WithTitle_SetsTitle()
        {
            string title = "TestCategory";
            var category = new Category(title);
            Assert.AreEqual(title, category.Title);
        }

        [TestMethod]
        public void SetParentCategoryId_ValidParentId_SetsParentCategoryIdAndIndex()
        {
            Guid parentCategoryId = Guid.NewGuid();
            mockRepository.Setup(repo => repo.IsExist(parentCategoryId)).Returns(true);
            mockRepository.Setup(repo => repo.GetById(parentCategoryId)).Returns(new Category("ParentCategory"));
            var category = new Category();
            category.SetParentCategoryId(parentCategoryId, mockRepository.Object);
            Assert.AreEqual(parentCategoryId, category.ParentCategoryId);
            Assert.AreEqual(1, category.Index);
        }

        [TestMethod]
        public void SetParentCategoryId_InvalidParentId_ThrowsCategoryNotExistException()
        {
            Guid invalidParentCategoryId = Guid.NewGuid();
            mockRepository.Setup(repo => repo.IsExist(invalidParentCategoryId)).Returns(false);
            var category = new Category();
            Assert.ThrowsException<CategoryNotExistException>(() => category.SetParentCategoryId(invalidParentCategoryId, mockRepository.Object));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void SetTitle_InvalidTitle_ThrowsArgumentNullException(string invalidTitle)
        {
            var category = new Category();
            Assert.ThrowsException<ArgumentNullException>(() => category.SetTitle(invalidTitle));
        }

        [TestMethod]
        public void SetTitle_ValidTitle_SetsTitle()
        {
            var category = new Category();
            string validTitle = "NewTitle";
            category.SetTitle(validTitle);
            Assert.AreEqual(validTitle, category.Title);
        }

        [TestMethod]
        public void GetTitle_ReturnsTitle()
        {
            string title = "TestCategory";
            var category = new Category(title);
            string retrievedTitle = category.Title;
            Assert.AreEqual(title, retrievedTitle);
        }

        [TestMethod]
        public void GetParentCategoryId_ReturnsParentCategoryId()
        {
            Guid parentCategoryId = Guid.NewGuid();
            mockRepository.Setup(repo => repo.IsExist(parentCategoryId)).Returns(true);
            mockRepository.Setup(repo => repo.GetById(parentCategoryId)).Returns(new Category("ParentCategory"));
            var category = new Category();
            category.SetParentCategoryId(parentCategoryId, mockRepository.Object);
            Guid? retrievedParentCategoryId = category.ParentCategoryId;
            Assert.AreEqual(parentCategoryId, retrievedParentCategoryId);
        }

        [TestMethod]
        public void GetIndex_ReturnsIndex()
        {
            string title = "TestCategory";
            var category = new Category(title);
            int retrievedIndex = category.Index;
            Assert.AreEqual(0, retrievedIndex);
        }
    }
}
