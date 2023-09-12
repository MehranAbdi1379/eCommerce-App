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
    public class UpdateCategoryParentCategoryIdHandler : IRequestHandler<UpdateCategoryParentCategoryIdCommand, Category>
    {
        private readonly ICategoryRepository categoryRepository;
        public UpdateCategoryParentCategoryIdHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task<Category> Handle(UpdateCategoryParentCategoryIdCommand request, CancellationToken cancellationToken)
        {
            var category = categoryRepository.GetById(request.dto.Id);
            category.SetParentCategoryId(request.dto.ParentId, categoryRepository);
            categoryRepository.Update(category);
            categoryRepository.Save();
            return Task.FromResult(category);
        }
    }
}
