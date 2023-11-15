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
    public class CreateCategoryRootHandler : IRequestHandler<CreateCategoryRootCommand, Category>
    {
        private readonly ICategoryRepository categoryRepository;
        public CreateCategoryRootHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task<Category> Handle(CreateCategoryRootCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.dto.Title, categoryRepository);
            categoryRepository.Create(category);
            categoryRepository.Save();
            return Task.FromResult(category);
        }
    }
}
