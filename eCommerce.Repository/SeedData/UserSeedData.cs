using Bogus;
using eCommerce.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Authentication.SeedData
{
    public class UserSeedData
    {
        private readonly UserManager<IdentityUser> userManager;
        public UserSeedData(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public void SeedData()
        {
            var userFaker = new Faker<IdentityUser>()
            .RuleFor(c => c.Email, f => f.Person.Email);

            var faker = new Faker();

            var users = userFaker.Generate(40);

            foreach (var user in users)
            {
                userManager.CreateAsync(user, "123456");
                userManager.AddToRoleAsync(user, "customer");
            }
        }
    }
}
