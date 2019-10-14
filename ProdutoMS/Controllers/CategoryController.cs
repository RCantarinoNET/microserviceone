using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProdutoMS.Repositories.Interfaces;

namespace ProdutoMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _category;

        public CategoryController(ICategoryRepository category)
        {
            this._category = category;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cats = await  _category.GetAll();
            return new OkObjectResult(cats);
        }
        
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var cat = await _category.GetById(id);
            if (cat == null)
                return BadRequest("Categoria nao encontrada");
            
            return new OkObjectResult(cat);
        }

    }
}