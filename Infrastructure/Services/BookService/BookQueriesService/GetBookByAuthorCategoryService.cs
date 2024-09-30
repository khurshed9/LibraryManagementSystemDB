using Dapper;
using LibraryManagementSystemDb.Infrastructure.Models.Book.BookQueries;
using Npgsql;

namespace LibraryManagementSystemDb.Infrastructure.Services.BookRental.BookQueriesService;

public class GetBookByAuthorCategoryService
{
    public async Task<IEnumerable<GetBookByAuthorCategory>> GetBookByAuthorCategories(Guid authorId, Guid categoryId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetBookByAuthorCategory>(SqlCommand.Get, new { authorid = @authorId, categoryid = @categoryId});
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
    public const string Get = @"select * from books
                                where authorid = @authorId::uuid and categoryid = @categoryId::uuid
                               ";
}