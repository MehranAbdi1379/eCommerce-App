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
    public class UpdateCategoryDeleteParentCategoryIdHandler : IRequestHandler<UpdateCategoryDeleteParentCategoryIdCommand, Category>
    {
        private readonly ICategoryRepository categoryRepository;
        public UpdateCategoryDeleteParentCategoryIdHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Task<Category> Handle(UpdateCategoryDeleteParentCategoryIdCommand request, CancellationToken cancellationToken)
        {
            var category = categoryRepository.GetById(request.dto.Id);
            category.RemoveParentCategoryId(categoryRepository);
            categoryRepository.Update(category);
            categoryRepository.Save();
            return Task.FromResult(category);
        }
    }
}
