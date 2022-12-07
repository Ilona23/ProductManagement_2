using Microsoft.EntityFrameworkCore;
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

        public string GetProductName(int Id)
        {
            var product = _context.Products.Find(Id);

            if (product == null)
            {
                throw new ArgumentException($"Product with id {Id} doesn't exist");
            }

            return product.Name;
        }

        public ProductModel CreateProduct(ProductModel product)
        {
            var productAlreadyExists = _context.Products.Any(p => p.Name == product.Name);

            if (productAlreadyExists)
            {
                throw new DbUpdateException($"Product with name '{product.Name}' already exist.");
            }

            var productEntity = _productMapper.MapFromModelToEntity(product);

            _context.Products.Add(productEntity);
            _context.SaveChanges();

            var createCategoryResponse = new ProductModel()
            {
                Id = productEntity.Id,
                Category = productEntity.Category,
                Price = productEntity.Price,
                Name = productEntity.Name,
                Description = productEntity.Description,
            };

            return createCategoryResponse;
        }
    }
}
