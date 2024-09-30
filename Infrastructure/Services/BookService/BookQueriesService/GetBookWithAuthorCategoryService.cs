using Dapper;
using LibraryManagementSystemDb.Infrastructure.Models.Book.BookQueries;
using Npgsql;

namespace LibraryManagementSystemDb.Infrastructure.Services.BookRental.BookQueriesService;

public class GetBookWithAuthorCategoryService
{
    public async Task<IEnumerable<GetBookWithAuthorCategory>> GetBookWithAuthorCategory()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetBookWithAuthorCategory>(SqlCommand.SelectBookWithAuthorCategory);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

file class SqlCommand
{
    public const string SelectBookWithAuthorCategory = @"select b.id, b.title, a.firstName || ' ' || a.lastName as authorName,a.dateOfBirth as authorDateOfBirth,a.biography as authorBiography, c.name as authorName from books b 
                                join authors a on a.id = b.authorId
                                join categories c on c.id = b.categoryId
                               ";
}