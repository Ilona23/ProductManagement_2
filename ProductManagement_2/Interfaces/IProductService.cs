using ProductManagement_2.Models;

namespace ProductManagement_2.Interfaces
{
    public interface IProductService
    {
        ProductModel GetProduct(int Id);
    }
}
