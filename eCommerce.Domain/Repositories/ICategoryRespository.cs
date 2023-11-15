using eCommerce.Domain.Models;
using Framework.Repository;

namespace eCommerce.Domain.Repositories
{
    public interface ICategoryRepository: IBaseRepository<Category>
    {
        public List<Category> GetSubCategoriesByParentId(Guid parentId);
        public List<Category> GetNeighboorCategories(Guid parentCategoryId);
        public List<Category> GetRootCategories();
        public List<Category> GetAllSubCategoriesByParentId(Guid parentId);
    }
}