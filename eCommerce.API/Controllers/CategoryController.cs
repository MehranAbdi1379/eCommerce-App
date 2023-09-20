using eCommerce.Domain.Models;
using eCommerce.Service;
using eCommerce.Service.Contracts.DTO;
using Microsoft.AspNetCore.Authorization;
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

        [Route("get-all-sub-categories-by-parent-id")]
        [HttpGet]
        public IActionResult GetAllSubCategories([FromQuery] IdDTO dto) => Ok(categoryService.GetAllSubCategoriesByParentId(dto));

        [Route("create-root")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<Category> CreateRoot(CategoryRootCreateDTO dto) => await categoryService.CreateRoot(dto);

        [Route("create-with-parent")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<Category> CreateWithParent(CategoryWithParentCreateDTO dto) => await categoryService.CreateWithParent(dto);

        [Route("update")]
        [Authorize(Roles = "admin")]
        [HttpPatch]
        public async Task<Category> Update(CategoryUpdateDTO dto) => await categoryService.Update(dto);

        [Route("update-parent-id")]
        [Authorize(Roles = "admin")]
        [HttpPatch]
        public async Task<Category> UpdateParentId(CategoryUpdateParentIdDTO dto) => await categoryService.UpdateParentId(dto);

        [Route("remove-parent-id")]
        [Authorize(Roles = "admin")]
        [HttpPatch]
        public async Task<Category> UpdateRemoveParentId(IdDTO dto) => await categoryService.UpdateRemoveParentId(dto);

        [Route("delete")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<Category> Delete(IdDTO dto) => await categoryService.Delete(dto);
    }
}
