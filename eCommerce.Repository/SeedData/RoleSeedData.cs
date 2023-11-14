using eCommerce.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Authentication.SeedData
{
    public class RoleSeedData
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleSeedData(RoleManager<IdentityRole> userManager)
        {
            this.roleManager = userManager;
        }
        public async Task SeedData()
        {
            List<IdentityRole> IdentityRoles = new List<IdentityRole>()
        {
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "customer",
                NormalizedName = "CUSTOMER"
            }
            ,
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            }
            ,new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "seller",
                NormalizedName = "SELLER"
            }
        };

            foreach (var role in IdentityRoles)
            {
                await roleManager.CreateAsync(role);
            }
    }
    }
}
