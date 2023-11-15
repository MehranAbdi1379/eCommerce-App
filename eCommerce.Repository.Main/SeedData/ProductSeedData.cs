using eCommerce.Repository.Main.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Main.SeedData
{
    public class ProductSeedData
    {
        private readonly eCommerceDBContext context;
        public ProductSeedData(eCommerceDBContext context)
        {
            this.context = context;
        }

        public void SeedData()
        {
            
        }
    }
}
