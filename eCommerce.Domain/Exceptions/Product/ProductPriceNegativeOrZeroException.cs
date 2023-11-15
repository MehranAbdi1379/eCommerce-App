using System.Runtime.Serialization;

namespace eCommerce.Domain.Exceptions
{
    public class ProductPriceNegativeOrZeroException : Exception
    {
        public override string Message => ExceptionMessages.ProductPriceNegativeOrZeroExceptionMessage;
    }
}