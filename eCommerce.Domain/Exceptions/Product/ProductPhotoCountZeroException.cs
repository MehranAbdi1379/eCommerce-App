using System.Runtime.Serialization;

namespace eCommerce.Domain.Exceptions
{
    public class ProductPhotoCountZeroException : Exception
    {
        public override string Message => ExceptionMessages.ProductPhotoCountZeroExceptionMessage;
    }
}