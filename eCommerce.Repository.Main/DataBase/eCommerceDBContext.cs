using eCommerce.Domain.Models;
using eCommerce.Repository.Main.Configurations;
using Framework.Repository;
using Microsoft.AspNetCore.Identity;
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
        public eCommerceDBContext(DbContextOptions<eCommerceDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CategoryConfiguration());
        }

        public DbSet<Category> Categories { get; set; }
    }
}
