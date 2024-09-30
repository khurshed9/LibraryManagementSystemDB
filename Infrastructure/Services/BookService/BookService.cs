using Dapper;
using LibraryManagementSystemDb.Infrastructure.Models.Book;
using LibraryManagementSystemDb.Infrastructure.Models.Book.BookQueries;
using Npgsql;

namespace LibraryManagementSystemDb.Infrastructure.Services.BookService;

public class BookService : IBookService
{
    public async Task<IEnumerable<Book>> GetBooks()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Book>(SqlCommandBook.GetBooks);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Book?> GetBookById(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QuerySingleOrDefaultAsync<Book>(SqlCommandBook.GetBookById, new { Id = id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateBook(Book book)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandBook.CreateBook, book) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateBook(Book book)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandBook.UpdateBook, book) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteBook(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandBook.DeleteBook, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    
}

