using Bogus;
using eCommerce.Domain.Models;
using eCommerce.Repository.Main.DataBase;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Main.SeedData
{
    public class CategorySeedData
    {
        private readonly eCommerceDBContext context;
        public CategorySeedData(eCommerceDBContext context)
        {
            this.context = context;
        }

        public void SeedData()
        {
            var categoryFaker = new Faker<Category>()
            .RuleFor(c => c.Title, f => f.Commerce.Categories(1)[0]);

            var faker = new Faker();

            var categories = categoryFaker.Generate(20);

            for (int i = 0; i < categories.Count; i++)
            {
                var category = categories[i];
                if (categories.Count > 0 && category.Id != categories[0].Id)
                {
                    if (!faker.Random.Bool(0.25f))
                    {
                        Guid parentId;
                        do
                        {
                            int index = faker.Random.Int(0, i);
                            parentId = categories[index].Id;
                        } while (parentId == category.Id);
                        var categoryRepository = new CategoryRespository(context);
                        category.SetParentCategoryId(parentId, categoryRepository);
                    }
                }
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}
