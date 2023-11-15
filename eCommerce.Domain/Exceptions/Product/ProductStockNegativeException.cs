using System.Runtime.Serialization;

namespace eCommerce.Domain.Exceptions
{
    public class ProductStockNegativeException : Exception
    {
        public override string Message => ExceptionMessages.ProductStockNegativeExceptionMessage;
    }
}