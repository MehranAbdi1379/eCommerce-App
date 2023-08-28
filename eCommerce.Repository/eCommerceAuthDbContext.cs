using Framework.Authentication.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Authentication
{
    public class eCommerceAuthDbContext : AuthenticationDbContext
    {
        public eCommerceAuthDbContext(DbContextOptions options) : base(options, AuthRoles.IdentityRoles)
        {
        }
    }
}
