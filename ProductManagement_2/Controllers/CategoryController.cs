using Microsoft.AspNetCore.Mvc;
using ProductManagement_2.Interfaces;
using ProductManagement_2.Models;

namespace ProductManagement_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }    

        [HttpGet("getCategory")]
        public GetCategoryResponse GetCategory(int Id) => _categoryService.GetCategory(Id);

        [HttpPost("createCategory")]
        public CreateCategoryResponse CreateCategory(CategoryModel category) => _categoryService.CreateCategory(category);

        [HttpDelete("deleteCategory")]
        public DeleteCategoryResponse DeleteCategory(int Id) => _categoryService.DeleteCategory(Id);

        [HttpPut("updateCategory")]
        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request) => _categoryService.UpdateCategory(request);

    }
}





















//[HttpGet()]
//public Category Get(int Id)
//{
//    var category = _context.Categories.Find(Id); // get from base, we have entity type object

//    return category;
//}

//[HttpDelete()]
//public void Delete(int Id)
//{
//    var categoryToDelete = _context.Categories.Find(Id);

//    if (categoryToDelete == null)
//    {
//        throw new DbUpdateException($"Category with id '{Id}' doesn't exist.");
//    }
//    //_context.Categories.RemoveRange(_context.Categories);
//    _context.Categories.Remove(categoryToDelete);
//    _context.SaveChanges();
//}

//[HttpPut()]
//public Category Update(Category categoryToUpdate)
//{
//    var existingCategoryToUpdate = _context.Categories.Find(categoryToUpdate.Id);

//    if (existingCategoryToUpdate == null)
//    {
//        throw new DbUpdateException($"Category with Id {categoryToUpdate.Id} does not exist ");
//    }

//    existingCategoryToUpdate.Name = categoryToUpdate.Name;
//    existingCategoryToUpdate.Code = categoryToUpdate.Code;
//    existingCategoryToUpdate.Description = categoryToUpdate.Description;
//    //existingCategoryToUpdate.Comment = categoryToUpdate.Comment;

//    _context.SaveChanges();

//    return existingCategoryToUpdate;
//}