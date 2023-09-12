using eCommerce.Domain.Models;
using Framework.Repository;

namespace eCommerce.Repository.Main
{
    public interface ICategoryRepository: IBaseRepository<Category>
    {
        public List<Category> GetSubCategoriesByParentId(Guid parentId);
    }
}