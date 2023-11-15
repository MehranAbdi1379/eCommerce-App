using eCommerce.Domain.Exceptions;
using eCommerce.Domain.Exceptions.Category;
using eCommerce.Domain.Repositories;
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

        public void SetParentCategoryId(Guid parentCategoryId, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            CheckParentCategoryExist();
            CheckNeighboorCategoryTitle();
            CheckOwnParentCategory();
            CheckCategoryHasAnyProduct();
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
            void CheckNeighboorCategoryTitle()
            {
                var neightBoorCategories = categoryRepository.GetNeighboorCategories(parentCategoryId);
                foreach (var category in neightBoorCategories)
                {
                    if (category.Title == this.Title && this.Id != category.Id)
                        throw new CategoryNeighboorTitleExistsException();
                }
            }
            void CheckCategoryHasAnyProduct()
            {
                if (productRepository.CategoryHasAnyProduct(parentCategoryId))
                    throw new CategoryHasProductException();
            }
        }

        public void RemoveParentCategoryId(ICategoryRepository categoryRepository)
        {
            CheckRootCategoryTitle();
            ParentCategoryId = null;

            void CheckRootCategoryTitle()
            {
                var rootCategories = categoryRepository.GetRootCategories();
                foreach (var category in rootCategories)
                {
                    if (category.Title == this.Title && this.Id != category.Id)
                        throw new CategoryNeighboorTitleExistsException();
                }
            }
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
                    CheckRootTitle();
                }
                else
                {
                    CheckNeighboorTitle();
                }

                void CheckRootTitle()
                {
                    var rootCategories = categoryRepository.GetRootCategories();
                    foreach (var category in rootCategories)
                    {
                        if (category.Title == title && this.Id != category.Id)
                            throw new CategoryNeighboorTitleExistsException();
                    }
                }
                void CheckNeighboorTitle()
                {
                    var neightBoorCategories = categoryRepository.GetNeighboorCategories((Guid)ParentCategoryId);
                    foreach (var category in neightBoorCategories)
                    {
                        if (category.Title == title && this.Id != category.Id)
                            throw new CategoryNeighboorTitleExistsException();
                    }
                }
            }
        }
    }
}
