﻿using eCommerce.Domain.Models;
using eCommerce.Service.Contracts.DTO;

namespace eCommerce.Service
{
    public interface ICategoryService
    {
        Task<Category> Create(CategoryCreateDTO dto);
        Task<Category> Delete(IdDTO dto);
        Task<List<Category>> GetAll();
        Task<Category> GetById(IdDTO dto);
        Task<List<Category>> GetSubCategoriesByParentId(IdDTO dto);
        Task<Category> Update(CategoryUpdateDTO dto);
        Task<Category> UpdateParentId(CategoryUpdateParentIdDTO dto);
    }
}