using eCommerce.Domain.Exceptions;
using eCommerce.Domain.Exceptions.Category;
using eCommerce.Domain.Exceptions.Product;
using eCommerce.Domain.Repositories;
using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; private set; }
        public Guid CategoryId { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; } = 0;
        public string Description { get; private set; }
        public List<Guid> ProductPhotoIds { get; private set; }

        public Product(string title, 
            string description, 
            List<Guid> productPhotoIds, 
            decimal price, 
            int stock,
            Guid categoryId
            ,ICategoryRepository categoryRepository
            ,IProductRepository repository)
        {
            SetTitle(title,repository);
            SetDescription(description);
            SetPhotoUrls(productPhotoIds);
            SetPrice(price);
            SetCategoryId(categoryId, categoryRepository);
            SetStock(stock);
        }

        public void SetCategoryId(Guid categoryId, ICategoryRepository categoryRepository)
        {
            if (!categoryRepository.IsExist(categoryId))
                throw new CategoryNotExistException();
            if (categoryRepository.GetSubCategoriesByParentId(categoryId).Count != 0)
                throw new ProductCategoryWithSubCategoryException();
            CategoryId = categoryId;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ProductPriceNegativeOrZeroException();
            Price = price;
        }

        public void SetPhotoUrls(List<Guid> productPhotoIds)
        {
            if (productPhotoIds.Count == 0)
                throw new ProductPhotoCountZeroException();
            ProductPhotoIds = productPhotoIds;
        }

        public void SetDescription(string description)
        {
            if (description.Length < 10)
                throw new ProductDescriptionShorterThanTenLettersException();
            Description = description;
        }

        public void SetTitle(string title, IProductRepository repository)
        {
            if (repository.TitleExists(title))
                throw new ProductTitleExistException();
            if (title.Length < 5)
                throw new ProductTitleShortenThanFiveLettersException();
            Title = title;
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
                throw new ProductStockNegativeException();
            Stock = stock;
        }
    }
}
