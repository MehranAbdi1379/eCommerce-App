using eCommerce.Domain.Models;
using eCommerce.Service;
using eCommerce.Service.Contracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<List<Category>> GetAll() => await categoryService.GetAll();

        [Route("get-by-id")]
        [HttpGet]
        public async Task<Category> GetById([FromQuery] IdDTO dto) => await categoryService.GetById(dto);

        [Route("get-sub-categories-by-parent-id")]
        [HttpGet]
        public async Task<List<Category>> GetSubCategoriesByParentId(IdDTO dto) => await categoryService.GetSubCategoriesByParentId(dto);

        [Route("create")]
        [HttpPost]
        public async Task<Category> Create(CategoryCreateDTO dto) => await categoryService.Create(dto);

        [Route("update")]
        [HttpPatch]
        public async Task<Category> Update(CategoryUpdateDTO dto) => await categoryService.Update(dto);

        [Route("update-parent-id")]
        [HttpPatch]
        public async Task<Category> UpdateParentId(CategoryUpdateParentIdDTO dto) => await categoryService.UpdateParentId(dto);
    }
}
