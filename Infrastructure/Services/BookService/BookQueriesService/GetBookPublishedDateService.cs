using Dapper;
using LibraryManagementSystemDb.Infrastructure.Models.Book.BookQueries;
using Npgsql;

namespace LibraryManagementSystemDb.Infrastructure.Services.BookRental.BookQueriesService;

public class GetBookPublishedDateService
{
    public async Task<IEnumerable<GetBookPublishedDate5>> GetBookPublishedDate5()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetBookPublishedDate5>(SqlCommand.Get);
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
                              where Extract(Year from publisheddate) >= Extract(Year from current_date) - 5;";
}