using eCommerce.Domain.Models;
using Framework.Repository;

namespace eCommerce.Domain.Repositories
{
    public interface IProductRepository: IBaseRepository<Product>
    {
        public bool TitleExists(string title);
        public bool CategoryHasAnyProduct(Guid categoryId);
    }
}