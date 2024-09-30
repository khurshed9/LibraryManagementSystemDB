namespace LibraryManagementSystemDb.Infrastructure.Models.Category;

public class SqlCommandCategory
{
    public const string GetCategories = "select * from categories";
    
    public const string GetCategoryById = "select * from categories where id = @id";
    
    public const string CreateCategory = "insert into categories (id,name,createdAt) values (@id,@name,@createdAt)";
    
    public const string UpdateCategory = "update categories set id = @id,name = @name,createdAt = @createdAt where id = @id";
    
    public const string DeleteCategory = "delete from categories where id = @id";
}