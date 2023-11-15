using System.Runtime.Serialization;

namespace eCommerce.Domain.Exceptions
{
    public class ProductDescriptionShorterThanTenLettersException : Exception
    {
        public override string Message => ExceptionMessages.ProductDescriptionShorterThanTenLettersExceptionMessage;
    }
}