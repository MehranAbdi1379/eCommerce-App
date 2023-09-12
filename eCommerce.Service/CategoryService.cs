using eCommerce.Domain.Models;
using eCommerce.Service.CategoryCQs.Commands;
using eCommerce.Service.CategoryCQs.Queries;
using eCommerce.Service.Contracts.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediator mediator;
        public CategoryService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<Category> Create(CategoryCreateDTO dto) => await mediator.Send(new CreateCategoryCommand(dto));
        public async Task<Category> Delete(IdDTO dto) => await mediator.Send(new DeleteCategoryCommand(dto));
        public async Task<List<Category>> GetAll() => await mediator.Send(new GetAllCategoriesQuery());
        public async Task<Category> GetById(IdDTO dto) => await mediator.Send(new GetCategoryByIdQuery(dto));
        public async Task<List<Category>> GetSubCategoriesByParentId(IdDTO dto) => await mediator.Send(new GetSubCategoriesByParentIdQuery(dto));
        public async Task<Category> Update(CategoryUpdateDTO dto) => await mediator.Send(new UpdateCategoryCommand(dto));
        public async Task<Category> UpdateParentId(CategoryUpdateParentIdDTO dto) => await mediator.Send(new UpdateCategoryParentCategoryIdCommand(dto));
    }
}
