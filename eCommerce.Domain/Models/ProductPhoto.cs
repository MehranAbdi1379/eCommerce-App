using eCommerce.Domain.Repositories;
using Framework.Core.Domain;
using eCommerce.Domain.Exceptions.Product;
using eCommerce.Domain.Exceptions.ProductPhoto;

namespace eCommerce.Domain.Models
{
    public class ProductPhoto : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string PhotoPath { get; set; }

        public ProductPhoto(Guid productId, 
            string photoPath,
            IProductRepository productRepository)
        {
            SetProductId(productRepository,productId);
            SetPath(photoPath);
        }

        public ProductPhoto()
        {
            
        }

        public void SetPath(string photoPath)
        {
            CheckFileFormat();
            PhotoPath = photoPath;
            return;

            void CheckFileFormat()
            {
                var extension = Path.GetExtension(photoPath).ToLower();
                if (extension != ".jpg")
                    throw new PhotoFormatException();
            }
        }

        public void SetProductId(IProductRepository productRepository, Guid productId)
        {
            CheckProductExist();
            ProductId = productId;
            return;

            void CheckProductExist()
            {
                if (!productRepository.IsExist(productId))
                    throw new ProductNotExistException();
            }
        }
    }
}
