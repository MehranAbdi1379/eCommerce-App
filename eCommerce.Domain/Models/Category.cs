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

        public Category() { }

        public void SetParentCategoryId(Guid parentCategoryId, ICategoryRepository categoryRepository)
        {
            if (!categoryRepository.IsExist(parentCategoryId))
                throw new CategoryNotExistException();
            var neightBoorCategories = categoryRepository.GetNeighboorCategories(parentCategoryId);
            neightBoorCategories.Remove(this);
            foreach (var category in neightBoorCategories)
            {
                if (category.Title == this.Title)
                    throw new CategoryNeighboorTitleExistsException();
            }
            ParentCategoryId = parentCategoryId;
        }

        public void RemoveParentCategoryId(ICategoryRepository categoryRepository)
        {
            var rootCategories = categoryRepository.GetRootCategories();
            foreach (var category in rootCategories)
            {
                if (category.Title == this.Title)
                    throw new CategoryNeighboorTitleExistsException();
            }
            ParentCategoryId = null;
        }

        public void SetTitle(string title)
        {
            if (title == null || title == "")
                throw new ArgumentNullException("title");
            Title = title;
        }

        public string Title { get; private set; }
        public Guid? ParentCategoryId { get; private set; }
    }
}
