using System.Runtime.Serialization;

namespace eCommerce.Domain.Exceptions
{
    public class ProductTitleExistException : Exception
    {
        public override string Message => ExceptionMessages.ProductTitleExistExceptionMessage;
    }
}