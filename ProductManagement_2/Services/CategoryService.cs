using Microsoft.EntityFrameworkCore;
using ProductManagement_2.Interfaces;
using ProductManagement_2.Mapping;
using ProductManagement_2.Models;

namespace ProductManagement_2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductManagmentContext _context;
        private readonly IMapper<Entities.Category, CategoryModel> _categoryMapper;

        public CategoryService(ProductManagmentContext context)
        {
            _categoryMapper = new CategoryMapper();
            _context = context;
        }

        public CreateCategoryResponse CreateCategory(CategoryModel category)
        {
            var categoryAlreadyExists = _context.Categories.Any(p => p.Name == category.Name);

            if (categoryAlreadyExists)
            {
                throw new DbUpdateException($"Category with name '{category.Name}' already exist.");
            }

            var categoryEntity = _categoryMapper.MapFromModelToEntity(category);

            _context.Categories.Add(categoryEntity);
            _context.SaveChanges();

            var createCategoryResponse = new CreateCategoryResponse()
            { 
                Id = categoryEntity.Id,
                Code = categoryEntity.Code, 
                Name = categoryEntity.Name,
                Description = categoryEntity.Description,   
            };

            return createCategoryResponse;
        }

        public GetCategoryResponse GetCategory(int Id)
        {
            var category = _context.Categories.Find(Id); // get from base, we have entity type object
            if (category == null)
            {
                return new GetCategoryResponse { };
            }
            var categoryModel = _categoryMapper.MapFromEntityToModel(category); // using mapper to get category Model
            var response = new GetCategoryResponse { Category = categoryModel };

            return response;
        }

        public DeleteCategoryResponse DeleteCategory(int Id)
        {
            var categoryToDelete = _context.Categories.Find(Id);
            if (categoryToDelete == null)
            {
                throw new DbUpdateException($"Category with id '{Id}' doesn't exist.");
            }

            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();

            return new DeleteCategoryResponse() { IsDeleted = true};
        }

        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var existingCategoryToUpdate = _context.Categories.Find(updateCategoryRequest.CategoryToUpdate.Id);

            if (existingCategoryToUpdate == null)
            {
                throw new DbUpdateException($"Category with Id {updateCategoryRequest.CategoryToUpdate.Id} does not exist ");
            }

            _categoryMapper.MapFromModelToEntity(updateCategoryRequest.CategoryToUpdate, existingCategoryToUpdate);
            _context.SaveChanges();

            return new UpdateCategoryResponse { UpdatedCategory = updateCategoryRequest.CategoryToUpdate, IsUpdated = true };
        }
    }
}
