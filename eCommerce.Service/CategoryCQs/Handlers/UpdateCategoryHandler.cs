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
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly ICategoryRepository categoryRepository;
        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = categoryRepository.GetById(request.dto.Id);
            category.SetTitle(request.dto.Title);
            categoryRepository.Update(category);
            return Task.FromResult(category);
        }
    }
}
