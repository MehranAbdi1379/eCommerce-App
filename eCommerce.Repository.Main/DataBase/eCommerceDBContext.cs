using Framework.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Main.DataBase
{
    public class eCommerceDBContext : DataBaseContext
    {
        public eCommerceDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
