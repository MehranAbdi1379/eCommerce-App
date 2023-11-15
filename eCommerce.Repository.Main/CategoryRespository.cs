using eCommerce.Domain.Models;
using eCommerce.Domain.Repositories;
using eCommerce.Repository.Main.DataBase;
using Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Main
{
    public class CategoryRespository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRespository(eCommerceDBContext context) : base(context)
        {
        }

        public List<Category> GetSubCategoriesByParentId(Guid parentId)
        {
            return context.Set<Category>().Where(x => x.ParentCategoryId == parentId).ToList();
        }

        public List<Category> GetNeighboorCategories(Guid parentCategoryId)
        {
            return context.Set<Category>().Where(x => x.ParentCategoryId == parentCategoryId).ToList();
        }

        public List<Category> GetRootCategories()
        {
            return context.Set<Category>().Where(x => x.ParentCategoryId == null).ToList();
        }

        public List<Category> GetAllSubCategoriesByParentId(Guid parentId)
        {
            var category = GetById(parentId);
            var allCategories = new List<Category>();
            GetFirstLevelSubCategoriesAndAddThemToAllCategoriesReccursivly(allCategories, category);
            return allCategories;
        }

        private void GetFirstLevelSubCategoriesAndAddThemToAllCategoriesReccursivly(List<Category> categories, Category parentCategory)
        {
            var subCategories = GetSubCategoriesByParentId(parentCategory.Id);
            foreach (var subCategory in subCategories)
            {
                categories.Add(subCategory);
                GetFirstLevelSubCategoriesAndAddThemToAllCategoriesReccursivly(categories, subCategory);
            }
        }
    }
}
