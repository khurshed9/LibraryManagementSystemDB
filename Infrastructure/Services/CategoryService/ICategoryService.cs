using LibraryManagementSystemDb.Infrastructure.Models.Category;

namespace LibraryManagementSystemDb.Infrastructure.Services.CategoryService;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategories();

    Task<Category?> GetCategoryById(Guid categoryId);
    
    Task<bool> CreateCategory(Category category);
    
    Task<bool> UpdateCategory(Category category);
    
    Task<bool> DeleteCategory(Guid categoryId);
}