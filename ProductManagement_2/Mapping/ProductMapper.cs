using ProductManagement_2.Entities;
using ProductManagement_2.Interfaces;
using ProductManagement_2.Models;

namespace ProductManagement_2.Mapping
{
    public class ProductMapper : IMapper<Product, ProductModel>
    {
        public ProductModel MapFromEntityToModel(Product source)
        {
            return new ProductModel
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price,
                Category = source.Category,
                Description = source.Description,
            };
        }

        public Product MapFromModelToEntity(ProductModel source)
        {
            var entity = new Product();

            MapFromModelToEntity(source, entity);

            return entity;
        }

        public void MapFromModelToEntity(ProductModel source, Product target)
        {
            target.Name = source.Name;
            target.Description = source.Description;
            target.Category = source.Category;
            target.Price = source.Price;
            target.Id = source.Id;
        }
    }
}
