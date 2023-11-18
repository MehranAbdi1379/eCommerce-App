using eCommerce.Domain.Exceptions.Product;
using eCommerce.Domain.Exceptions.ProductPhoto;
using eCommerce.Domain.Models;
using eCommerce.Domain.Repositories;
using Moq;

namespace eCommerce.Domain.Tests.Models;

[TestClass]
public class ProductPhotoTest
{
    private readonly Mock<IProductRepository> productRepositoryMock = new();

    public ProductPhotoTest()
    {
        productRepositoryMock.Setup(repo => repo.IsExist(It.IsAny<Guid>())).Returns(true);
    }

    [TestMethod]
    public void SetPhotoPath_Retrieve()
    {
        var productPhoto = InitializeProductPhoto();
        Assert.AreEqual("Test.jpg", productPhoto.PhotoPath);
    }

    [TestMethod]
    public void SetProductId_Retrieve()
    {
        var productId = Guid.NewGuid();
        var productPhoto = new ProductPhoto(productId, "Test.jpg", productRepositoryMock.Object);
        Assert.AreEqual(productId, productPhoto.ProductId);
    }

    [TestMethod]
    public void SetPhotoPath_PhotoFormatNotSupported_ThrowException()
    {
        var productPhoto = InitializeProductPhoto();
        Assert.ThrowsException<PhotoFormatException>(() => productPhoto.SetPath("Test.png"));
    }

    [TestMethod]
    public void SetProductId_ProductNotExist_ThrowException()
    {
        var productPhoto = InitializeProductPhoto();
        productRepositoryMock.Setup(repo => repo.IsExist(It.IsAny<Guid>())).Returns(false);
        Assert.ThrowsException<ProductNotExistException>(() =>
            productPhoto.SetProductId(productRepositoryMock.Object, Guid.NewGuid()));
    }


    private ProductPhoto InitializeProductPhoto()
    {
        return new ProductPhoto(Guid.NewGuid(), "Test.jpg", productRepositoryMock.Object);
    }
}