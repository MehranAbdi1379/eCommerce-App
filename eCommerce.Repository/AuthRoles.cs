using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Authentication
{
    public static class AuthRoles
    {
        public static List<IdentityRole> IdentityRoles = new List<IdentityRole>()
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
    }
}
