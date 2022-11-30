using ProductManagement_2.Interfaces;
using ProductManagement_2.Mapping;
using ProductManagement_2.Models;

namespace ProductManagement_2.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductManagmentContext _context;
        private readonly IMapper<Entities.Product, ProductModel> _productMapper;

        public ProductService(ProductManagmentContext context)
        {
            _productMapper = new ProductMapper();
            _context = context;
        }

        public ProductModel GetProduct(int Id)
        {
            var product = _context.Products.Find(Id);

            if (product == null)
            {
                throw new ArgumentException($"Product with id {Id} doesn't exist");
            }

            var convertedProduct = _productMapper.MapFromEntityToModel(product);

            return convertedProduct;
        }    
    }
}
