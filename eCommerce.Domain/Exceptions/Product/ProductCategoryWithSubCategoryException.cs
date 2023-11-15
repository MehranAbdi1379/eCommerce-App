using System.Runtime.Serialization;

namespace eCommerce.Domain.Exceptions.Product
{
    public class ProductCategoryWithSubCategoryException : Exception
    {
        public override string Message => ExceptionMessages.ProductCategoryWithSubCategoryExceptionMessage;
    }
}