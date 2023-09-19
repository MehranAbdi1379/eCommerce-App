using eCommerce.Domain.Models;
using eCommerce.Repository.Main;
using eCommerce.Service.CategoryCQs.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.CategoryCQs.Handlers
{
    public class GetAllSubCategoriesByParentIdHandler : IRequestHandler<GetAllSubCategoriesByParentIdQuery, List<Category>>
    {
        private readonly ICategoryRepository categoryRepository;
        public GetAllSubCategoriesByParentIdHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task<List<Category>> Handle(GetAllSubCategoriesByParentIdQuery request, CancellationToken cancellationToken)
        {
            var category = categoryRepository.GetById(request.dto.Id);
            var allCategories = new List<Category>();
            GetFirstLevelSubCategoriesAndAddThemToAllCategoriesReccursivly(allCategories, category);
            return Task.FromResult(allCategories);
        }

        private void GetFirstLevelSubCategoriesAndAddThemToAllCategoriesReccursivly(List<Category> categories, Category parentCategory)
        {
            var subCategories = categoryRepository.GetSubCategoriesByParentId(parentCategory.Id);
            foreach (var subCategory in subCategories)
            {
                categories.Add(subCategory);
                GetFirstLevelSubCategoriesAndAddThemToAllCategoriesReccursivly(categories, subCategory);
            }
        }
    }
}
