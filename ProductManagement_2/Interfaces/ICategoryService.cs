using ProductManagement_2.Models;

namespace ProductManagement_2.Interfaces
{
    public interface ICategoryService
    {
        GetCategoryResponse GetCategory(int Id);
        CreateCategoryResponse CreateCategory(CategoryModel request)
;
        UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request);
        DeleteCategoryResponse DeleteCategory(int Id);
    }
}






