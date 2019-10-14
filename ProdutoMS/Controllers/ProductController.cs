using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProdutoMS.Repositories;

namespace ProdutoMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;

        public ProductController(IProductRepository product)
        {
            this._product = product;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cats = await  _product.GetAll();
            return new OkObjectResult(cats);
        }
        
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var cat = await _product.GetById(id);
            if (cat == null)
                return BadRequest("produto nao encontrada");
            
            return new OkObjectResult(cat);
        }
    }
}