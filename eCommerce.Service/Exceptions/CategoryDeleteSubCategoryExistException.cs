using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Exceptions
{
    public class CategoryDeleteSubCategoryExistException: Exception
    {
        public override string Message => "Can not delete a category with sub categories";
    }
}
