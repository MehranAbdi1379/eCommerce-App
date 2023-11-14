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
        public string Title { get; private set; }
        public Guid? ParentCategoryId { get; private set; }

        public Category(string title, ICategoryRepository categoryRepository)
        {
            SetTitle(title, categoryRepository);
        }

        public Category() { }

        public void SetParentCategoryId(Guid parentCategoryId, ICategoryRepository categoryRepository)
        {
            CheckParentCategoryExist();
            CheckNeighboorCategoryTitle(categoryRepository, parentCategoryId);
            CheckOwnParentCategory();
            ParentCategoryId = parentCategoryId;

            void CheckParentCategoryExist()
            {
                if (!categoryRepository.IsExist(parentCategoryId))
                    throw new CategoryNotExistException();
            }
            void CheckOwnParentCategory()
            {
                if (parentCategoryId == this.Id)
                    throw new CategoryOwnParentCategoryExcpetion();
            }
        }

        public void RemoveParentCategoryId(ICategoryRepository categoryRepository)
        {
            CheckRootCategoryTitle(categoryRepository);
            ParentCategoryId = null;
        }

        public void SetTitle(string title, ICategoryRepository categoryRepository)
        {
            CheckTitleForNullAndEmpty();
            CheckTitleDuplication();
            Title = title;

            void CheckTitleForNullAndEmpty()
            {
                if (title == null || title == "")
                    throw new ArgumentNullException("title");
            }
            void CheckTitleDuplication()
            {
                if (ParentCategoryId == null)
                {
                    CheckRootCategoryTitle(categoryRepository);
                }
                else
                {
                    CheckNeighboorCategoryTitle(categoryRepository, (Guid)ParentCategoryId);
                }
            }
        }


        private void CheckRootCategoryTitle(ICategoryRepository categoryRepository)
        {
            var rootCategories = categoryRepository.GetRootCategories();
            rootCategories.Remove(this);
            foreach (var category in rootCategories)
            {
                if (category.Title == this.Title)
                    throw new CategoryNeighboorTitleExistsException();
            }
        }
        private void CheckNeighboorCategoryTitle(ICategoryRepository categoryRepository, Guid parentCategoryId)
        {
            var neightBoorCategories = categoryRepository.GetNeighboorCategories(parentCategoryId);
            neightBoorCategories.Remove(this);
            foreach (var category in neightBoorCategories)
            {
                if (category.Title == this.Title)
                    throw new CategoryNeighboorTitleExistsException();
            }
        }
    }
}
