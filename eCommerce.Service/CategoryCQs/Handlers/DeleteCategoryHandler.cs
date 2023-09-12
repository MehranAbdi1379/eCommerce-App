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
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private readonly ICategoryRepository categoryRepository;
        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = categoryRepository.GetById(request.dto.Id);
            if (categoryRepository.GetSubCategoriesByParentId(request.dto.Id).Count != 0)
                throw new Exception();
            categoryRepository.Delete(category);
            categoryRepository.Save();
            return Task.FromResult(category);
        }
    }
}
