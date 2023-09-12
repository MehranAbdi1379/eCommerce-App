using Framework.Domain;
using System.Runtime.Serialization;

namespace eCommerce.Domain.Exceptions
{
    public class NegativeIndexException : DomainException
    {
        public override string Message => ExceptionMessages.NegativeIndexExceptionMessage;
    }
}