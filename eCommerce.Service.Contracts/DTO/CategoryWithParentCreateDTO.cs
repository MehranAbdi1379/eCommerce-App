﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Contracts.DTO
{
    public class CategoryWithParentCreateDTO
    {
        public string Title { get; set; }
        public Guid ParentId { get; set; }
    }
}
