using eCommerce.Domain.Models;
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
        public CreateCategoryWithParentHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Task<Category> Handle(CreateCategoryWithParentCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.dto.Title);
            category.SetParentCategoryId(request.dto.ParentId, categoryRepository);
            categoryRepository.Create(category);
            categoryRepository.Save();
            return Task.FromResult(category);
        }
    }
}
