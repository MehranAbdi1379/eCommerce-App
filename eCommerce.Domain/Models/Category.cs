using eCommerce.Domain.Exceptions;
using eCommerce.Repository.Main;
using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Models
{
    public class Category : BaseEntity
    {
        public Category(string title)
        {
            SetTitle(title);
        }

        public void SetParentCategoryId(Guid parentCategoryId, ICategoryRepository categoryRespository)
        {
            if (!categoryRespository.IsExist(parentCategoryId))
                throw new CategoryNotExistException();
            ParentCategoryId = parentCategoryId;
            Index = categoryRespository.GetById(parentCategoryId).Index + 1;
        }

        public void SetTitle(string title)
        {
            if (title == null || title == "")
                throw new ArgumentNullException("title");
            Title = title;
        }

        public string Title { get; private set; }
        public Guid ParentCategoryId { get; private set; }
        public int Index { get; private set; } = 0;
    }
}
