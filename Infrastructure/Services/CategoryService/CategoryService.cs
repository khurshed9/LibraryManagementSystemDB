using Dapper;
using LibraryManagementSystemDb.Infrastructure.Models.Category;
using Npgsql;

namespace LibraryManagementSystemDb.Infrastructure.Services.CategoryService;


public class CategoryService : ICategoryService
{
    public async Task<IEnumerable<Category>> GetCategories()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Category>(SqlCommandCategory.GetCategories);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Category?> GetCategoryById(Guid categoryId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QuerySingleOrDefaultAsync<Category>(SqlCommandCategory.GetCategoryById, new { Id = categoryId });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateCategory(Category category)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandCategory.CreateCategory, category) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateCategory(Category category)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandCategory.UpdateCategory, category) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteCategory(Guid categoryId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandCategory.DeleteCategory, new { Id = categoryId }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}
