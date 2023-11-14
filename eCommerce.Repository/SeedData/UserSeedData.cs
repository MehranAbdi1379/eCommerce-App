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
        private readonly UserManager<ApiUser> userManager;
        public UserSeedData(UserManager<ApiUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task SeedData()
        {
            await SeedData_SeedCustomers();
            await SeedData_SeedAdmin();
        }

        private async Task SeedData_SeedCustomers()
        {
            var userFaker = new Faker<ApiUser>()
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            .RuleFor(c => c.LastName , f => f.Person.LastName);

            var users = userFaker.Generate(20);

            foreach (var user in users)
            {
                user.UserName = user.Email;
                user.EmailConfirmed = true;
                await userManager.CreateAsync(user, "123456");
                await userManager.AddToRoleAsync(user, "customer");
            }
        }

        private async Task SeedData_SeedAdmin()
        {
            var admin = new ApiUser()
            {
                Email = "mehran@gmail.com",
                FirstName = "Mehran",
                LastName = "Abdi"
            };
            admin.UserName = admin.Email;
            admin.EmailConfirmed = true;

            await userManager.CreateAsync(admin, "m123456");
            await userManager.AddToRoleAsync(admin, "admin");
        }
    }
}
