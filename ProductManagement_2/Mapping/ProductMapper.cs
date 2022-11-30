using ProductManagement_2.Entities;
using ProductManagement_2.Interfaces;
using ProductManagement_2.Models;

namespace ProductManagement_2.Mapping
{
    public class ProductMapper : IMapper<Entities.Product, ProductModel>
    {
        public ProductModel MapFromEntityToModel(Entities.Product source)
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
            throw new NotImplementedException();
        }

        public void MapFromModelToEntity(ProductModel source, Product target)
        {
            throw new NotImplementedException();
        }
    }
}
