using Microsoft.AspNetCore.Mvc;
using OMS.API.Models.Dtos.CategoryDto;
using OMS.Data.Model.Entities;
using OMS.Maps;
using OMS.Queries.Interfaces;

namespace OMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryQueryProcessor _queryProcessor;
        private readonly IAutoMapper _autoMapper;
        readonly NorthwindContext _northwindContext;
        public CategoriesController(ICategoryQueryProcessor queryProcessor, IAutoMapper autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }

        [HttpGet("{id}")]
        public async Task<CategoryDtoGet> GetCategory(int id, CancellationToken token)
        {
            var item = await _queryProcessor.GetById(id, token);
            var model = _autoMapper.Map<CategoryDtoGet>(item);
            return model;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        {
            return await _northwindContext.Categories.ToListAsync();
        }
    }
}