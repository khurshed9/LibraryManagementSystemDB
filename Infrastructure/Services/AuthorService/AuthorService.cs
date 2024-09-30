using Dapper;
using LibraryManagementSystemDb.Infrastructure.Models.Author;
using Npgsql;

namespace LibraryManagementSystemDb.Infrastructure.Services.AuthorService;

public class AuthorService : IAuthorService
{
    public async Task<IEnumerable<Author>> GetAuthors()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Author>(SqlCommandAuthor.GetAuthors);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Author?> GetAuthorById(Guid authorId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QuerySingleOrDefaultAsync<Author>(SqlCommandAuthor.GetAuthorById, new { Id = authorId });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateAuthor(Author author)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandAuthor.CreateAuthor, author) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateAuthor(Author author)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandAuthor.UpdateAuthor, author) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteAuthor(Guid authorId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandAuthor.DeleteAuthor, new { Id = authorId }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}