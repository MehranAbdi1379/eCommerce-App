﻿using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Exceptions
{
    public class CategoryNeighboorTitleExistsException: DomainException
    {
        public override string Message => ExceptionMessages.CategoryNeighboorTitleExistsExceptionMessage;
    }
}
