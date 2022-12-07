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

        [HttpGet("getProductName")]
        public string GetProductName(int Id) => _productService.GetProductName(Id);

        [HttpGet("createProduct")]
        public ProductModel CreateProduct(ProductModel product) => _productService.CreateProduct(product);

    }
}
