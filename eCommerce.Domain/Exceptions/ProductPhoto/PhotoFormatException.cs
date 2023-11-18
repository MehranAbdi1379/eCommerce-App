using System.Runtime.Serialization;
using eCommerce.Domain.Exceptions;

namespace eCommerce.Domain.Exceptions.ProductPhoto
{
    public class PhotoFormatException : Exception
    {
        public override string Message => ExceptionMessages.PhotoFormatExceptionMessage;
    }
}