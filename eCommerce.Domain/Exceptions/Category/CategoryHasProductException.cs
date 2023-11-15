using System.Runtime.Serialization;

namespace eCommerce.Domain.Exceptions.Category
{
    public class CategoryHasProductException : Exception
    {
        public override string Message => ExceptionMessages.CategoryHasProductExceptionMessage;
    }
}