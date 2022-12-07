using ProductManagement_2.Models;

namespace ProductManagement_2.Interfaces
{
    public interface IProductService
    {
        ProductModel GetProduct(int Id);
        ProductModel CreateProduct(ProductModel productModel);
        string GetProductName(int Id);
        // void DeleteProduct(int Id);
        // void UpdateProduct(ProductModel productModel);
    }
}
