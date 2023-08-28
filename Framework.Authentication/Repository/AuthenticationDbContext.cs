using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Authentication.Repository
{
    public class AuthenticationDbContext: IdentityDbContext
    {
        private readonly List<IdentityRole> identityRoles;
        public AuthenticationDbContext(DbContextOptions options , List<IdentityRole> identityRoles) : base(options)
        {
            this.identityRoles = identityRoles;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(identityRoles);
        }
    }
}
