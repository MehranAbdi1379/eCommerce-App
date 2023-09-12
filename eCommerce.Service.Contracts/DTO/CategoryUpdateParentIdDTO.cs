using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Contracts.DTO
{
    public class CategoryUpdateParentIdDTO
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
    }
}
