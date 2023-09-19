using eCommerce.Domain.Models;
using eCommerce.Repository.Main;
using eCommerce.Service.CategoryCQs.Commands;
using eCommerce.Service.CategoryCQs.Handlers;
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
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(IMediator mediator, ICategoryRepository categoryRepository)
        {
            this.mediator = mediator;
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateRoot(CategoryRootCreateDTO dto) => await mediator.Send(new CreateCategoryRootCommand(dto));
        public async Task<Category> CreateWithParent(CategoryWithParentCreateDTO dto) => await mediator.Send(new CreateCategoryWithParentCommand(dto));
        public async Task<Category> Delete(IdDTO dto) => await mediator.Send(new DeleteCategoryCommand(dto));
        public async Task<List<Category>> GetAll() => await mediator.Send(new GetAllCategoriesQuery());
        public async Task<Category> GetById(IdDTO dto) => await mediator.Send(new GetCategoryByIdQuery(dto));
        public async Task<List<Category>> GetSubCategoriesByParentId(IdDTO dto) => await mediator.Send(new GetSubCategoriesByParentIdQuery(dto));
        public async Task<Category> Update(CategoryUpdateDTO dto) => await mediator.Send(new UpdateCategoryCommand(dto));
        public async Task<Category> UpdateParentId(CategoryUpdateParentIdDTO dto) => await mediator.Send(new UpdateCategoryParentCategoryIdCommand(dto));
        public async Task<List<Category>> GetAllSubCategoriesByParentId(IdDTO dto) => await mediator.Send(new GetAllSubCategoriesByParentIdQuery(dto));
        
    }
}
