using eCommerce.Domain.Models;
using eCommerce.Domain.Repositories;
using eCommerce.Repository.Main;
using eCommerce.Service.CategoryCQs.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.CategoryCQs.Handlers
{
    public class CreateCategoryWithParentHandler : IRequestHandler<CreateCategoryWithParentCommand, Category>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;
        public CreateCategoryWithParentHandler(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }
        public Task<Category> Handle(CreateCategoryWithParentCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.dto.Title, categoryRepository);
            category.SetParentCategoryId(request.dto.ParentId, categoryRepository, productRepository);
            categoryRepository.Create(category);
            categoryRepository.Save();
            return Task.FromResult(category);
        }
    }
}
