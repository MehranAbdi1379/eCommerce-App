using eCommerce.Domain.Models;
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
    public class eCommerceAuthDbContext : AuthenticationDbContext<ApiUser>
    {
        public eCommerceAuthDbContext(DbContextOptions<eCommerceAuthDbContext> options) : base(options)
        {
        }
    }
}
