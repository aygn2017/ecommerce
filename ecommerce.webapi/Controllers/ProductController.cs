using Microsoft.AspNetCore.Mvc;

namespace ecommerce.webapi.Controllers
{
    // localhost:4200/api/products
    // localhost:4200/api/products/2
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        public ProductsController()
        {

        }
        private static readonly string[] Products = {
            "samsung s8","samsung s10","iphone 12","iphone 12 mini"
        };

        [HttpGet]
        public string[] GetProducts()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return Products[id];
        }
    }
}
