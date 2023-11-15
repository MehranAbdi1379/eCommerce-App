using eCommerce.Domain.Models;
using eCommerce.Domain.Repositories;
using eCommerce.Repository.Main;
using eCommerce.Service.CategoryCQs.Commands;
using eCommerce.Service.CategoryCQs.Handlers;
using eCommerce.Service.Contracts.DTO;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Tests.HandlerTests
{
    public class CategoryHandlerTests
    {
        //private readonly Mock<ICategoryRepository> mock = new();
        //private readonly Mock<IProductRepository> productRepository = new();
        //public CategoryHandlerTests()
        //{
        //    mock.Setup(x => x.IsExist(It.IsAny<Guid>())).Returns(true);
        //    mock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(new Category("title",mock.Object));
        //    mock.Setup(x => x.GetNeighboorCategories(It.IsAny<Guid>())).Returns(new List<Category>());
        //    mock.Setup(x => x.GetRootCategories()).Returns(new List<Category>());
        //}

        //[TestMethod]
        //public void CreateCategoryRoot()
        //{
        //    var handler = new CreateCategoryRootHandler(mock.Object);
        //    var category = handler.Handle(new CreateCategoryRootCommand(
        //        new CategoryRootCreateDTO { Title = "title" }),new CancellationToken()).Result;
        //    Assert.AreEqual("title", category.Title);
        //    Assert.AreEqual(null, category.ParentCategoryId);
        //}

        //[TestMethod]
        //public void CreateCategoryWithParentId()
        //{
        //    var handler = new CreateCategoryWithParentHandler(mock.Object, productRepository.Object);
        //    var parentId = new Guid();
        //    var category = handler.Handle(new CreateCategoryWithParentCommand(
        //        new CategoryWithParentCreateDTO { ParentId = parentId, Title = "title" }),new CancellationToken()).Result;
        //    Assert.AreEqual("title", category.Title);
        //    Assert.AreEqual(parentId, category.ParentCategoryId);
        //}
    }
}
