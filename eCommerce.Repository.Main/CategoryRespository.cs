using eCommerce.Domain.Models;
using eCommerce.Repository.Main.DataBase;
using Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Repository.Main
{
    public class CategoryRespository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRespository(eCommerceDBContext context) : base(context)
        {
        }

        public List<Category> GetSubCategoriesByParentId(Guid parentId)
        {
            return context.Set<Category>().Where(x => x.ParentCategoryId == parentId).ToList();
        }
    }
}
