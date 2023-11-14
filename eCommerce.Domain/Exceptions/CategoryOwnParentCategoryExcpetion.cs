﻿using Framework.Domain;
using System.Runtime.Serialization;

namespace eCommerce.Domain.Exceptions
{
    public class CategoryOwnParentCategoryExcpetion : DomainException
    {
        public override string Message => ExceptionMessages.CategoryOwnParentCategoryExcpetionMessage;
    }
}