using eCommerce.Domain.Models;
using eCommerce.Domain.Repositories;
using eCommerce.Repository.Main.DataBase;
using Framework.Repository;

namespace eCommerce.Repository.Main;

public class ProductPhotoRepository: BaseRepository<ProductPhoto>, IProductPhotoRepository
{
    public ProductPhotoRepository(eCommerceDBContext context) : base(context)
    {
    }
}