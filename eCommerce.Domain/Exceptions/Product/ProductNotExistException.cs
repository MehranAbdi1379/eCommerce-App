using System.Runtime.Serialization;
using eCommerce.Domain.Exceptions;

namespace eCommerce.Domain.Exceptions.Product
{
    public class ProductNotExistException : Exception
    {
        public override string Message => ExceptionMessages.ProductNotExistExceptionMessage;
    }
}