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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(eCommerceDBContext context) : base(context)
        {
        }

        public bool TitleExists(string title)
        {
            return context.Set<Product>().Any(x => x.Title == title);
        }

        public bool CategoryHasAnyProduct(Guid categoryId)
        {
            return context.Set<Product>().Any(x => x.CategoryId == categoryId);
        }
    }
}
