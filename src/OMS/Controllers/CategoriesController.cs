using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMS.Queries.Interfaces;

namespace OMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryQueryProcessor _queryProcessor;

    }
}
