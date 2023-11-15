using System.Runtime.Serialization;

namespace eCommerce.Domain.Exceptions
{
    public class ProductTitleShortenThanFiveLettersException : Exception
    {
        public override string Message => ExceptionMessages.ProductTitleShortenThanFiveLettersExceptionMessage;
    }
}