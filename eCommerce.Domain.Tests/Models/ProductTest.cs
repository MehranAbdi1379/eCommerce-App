using eCommerce.Domain.Exceptions;
using eCommerce.Domain.Exceptions.Category;
using eCommerce.Domain.Exceptions.Product;
using eCommerce.Domain.Models;
using eCommerce.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Tests.Models
{
    [TestClass]
    public class ProductTest
    {
        private Mock<ICategoryRepository> categoryRepository = new Mock<ICategoryRepository>();
        private Mock<IProductRepository> productRepository = new Mock<IProductRepository>();

        public ProductTest()
        {
            categoryRepository.Setup(repo => repo.IsExist(It.IsAny<Guid>())).Returns(true);
            categoryRepository.Setup(repo => repo.GetSubCategoriesByParentId(It.IsAny<Guid>())).Returns(new List<Category>());

            productRepository.Setup(repo => repo.TitleExists(It.IsAny<string>())).Returns(false);
        }
        [TestMethod]
        public void Constructor_ValidParameters_ProductCreatedSuccessfully()
        {
            var title = "Valid Title";
            var description = "Valid Description";
            var photoURLs = new List<string> { "url1", "url2" };
            var price = 15.6m;
            var categoryId = Guid.NewGuid();
            var stock = 5;
            var categoryRepository = new Mock<ICategoryRepository>();
            categoryRepository.Setup(repo => repo.IsExist(It.IsAny<Guid>())).Returns(true);
            categoryRepository.Setup(repo => repo.GetSubCategoriesByParentId(It.IsAny<Guid>())).Returns(new List<Category>());
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(repo => repo.TitleExists(It.IsAny<string>())).Returns(false);

            var product = new Product(title, description, photoURLs, price, stock, categoryId, categoryRepository.Object, productRepository.Object);

            Assert.IsNotNull(product);
            Assert.AreEqual(title, product.Title);
            Assert.AreEqual(description, product.Description);
            CollectionAssert.AreEqual(photoURLs, product.PhotoURLs);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(categoryId, product.CategoryId);
            Assert.AreEqual(stock, product.Stock);
        }

        [TestMethod]
        public void SetPrice_InvalidPrice_ThrowsProductPriceNegativeOrZeroException()
        {
            var product = CreateValidProduct();
            Assert.ThrowsException<ProductPriceNegativeOrZeroException>(() => product.SetPrice(0));
        }

        [TestMethod]
        public void SetPhotoURLs_EmptyPhotoURLs_ThrowsProductPhotoCountZeroException()
        {
            var product = CreateValidProduct();
            Assert.ThrowsException<ProductPhotoCountZeroException>(() => product.SetPhotoUrls(new List<string>()));
        }

        [TestMethod]
        public void SetTitle_TitleExists_ThrowTitleExistsException()
        {
            var product = CreateValidProduct();
            productRepository.Setup(repo => repo.TitleExists(It.IsAny<string>())).Returns(true);
            Assert.ThrowsException<ProductTitleExistException>(() => product.SetTitle(product.Title, productRepository.Object));
        }

        [TestMethod]
        public void SetTitle_ShortTitle_ThrowTitleShortException()
        {
            var product = CreateValidProduct();
            Assert.ThrowsException<ProductTitleShortenThanFiveLettersException>(() => product.SetTitle("dabg", productRepository.Object));
        }

        [TestMethod]
        public void SetCategoryId_NotExist_ThrowCategoryNotExistException()
        {
            var product = CreateValidProduct();
            categoryRepository.Setup(repo => repo.IsExist(It.IsAny<Guid>())).Returns(false);
            Assert.ThrowsException<CategoryNotExistException>(() => product.SetCategoryId(product.CategoryId, categoryRepository.Object));
        }

        [TestMethod]
        public void SetCategoryId_HasSubCategories_ThrowCategoryHasSubCategoriesException()
        {
            var product = CreateValidProduct();
            categoryRepository.Setup(repo => repo.GetSubCategoriesByParentId(It.IsAny<Guid>())).Returns(new List<Category>() { new Category() });
            Assert.ThrowsException<ProductCategoryWithSubCategoryException>(() => product.SetCategoryId(Guid.NewGuid(), categoryRepository.Object));
        }

        [TestMethod]
        public void SetDescription_Short_ThrowDescriptionShortException()
        {
            var product = CreateValidProduct();
            Assert.ThrowsException<ProductDescriptionShorterThanTenLettersException>(() => product.SetDescription("abcdefgad"));
        }

        [TestMethod]
        public void SetStock_Negative_ThrowException()
        {
            var product = CreateValidProduct();
            Assert.ThrowsException<ProductStockNegativeException>(() => product.SetStock(-1));
        }

        private Product CreateValidProduct()
        {
            var title = "Valid Title";
            var description = "Valid Description";
            var photoURLs = new List<string> { "url1", "url2" };
            var price = 10.99m;
            var categoryId = Guid.NewGuid();
            var stock = 54;
            return new Product(title, description, photoURLs, price, stock, categoryId, categoryRepository.Object, productRepository.Object);
        }
    }
}
