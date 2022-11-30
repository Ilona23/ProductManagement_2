using Microsoft.AspNetCore.Mvc;
using ProductManagement_2.Interfaces;
using ProductManagement_2.Models;

namespace ProductManagement_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getProduct")]
        public ProductModel GetProduct(int Id) => _productService.GetProduct(Id);
    }
}
