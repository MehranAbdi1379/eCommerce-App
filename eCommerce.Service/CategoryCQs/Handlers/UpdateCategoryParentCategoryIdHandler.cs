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
    public class UpdateCategoryParentCategoryIdHandler : IRequestHandler<UpdateCategoryParentCategoryIdCommand, Category>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;
        public UpdateCategoryParentCategoryIdHandler(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public Task<Category> Handle(UpdateCategoryParentCategoryIdCommand request, CancellationToken cancellationToken)
        {
            var category = categoryRepository.GetById(request.dto.Id);
            category.SetParentCategoryId(request.dto.ParentId, categoryRepository,productRepository);
            categoryRepository.Update(category);
            categoryRepository.Save();
            return Task.FromResult(category);
        }
    }
}
