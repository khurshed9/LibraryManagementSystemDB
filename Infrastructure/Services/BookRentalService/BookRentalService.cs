using Dapper;
using LibraryManagementSystemDb.Infrastructure.Models.BookRentals;
using Npgsql;

namespace LibraryManagementSystemDb.Infrastructure.Services.BookRental;

public class BookRentalService : IBookRentalService
{
    public async Task<IEnumerable<Models.BookRentals.BookRental>> GetBookRentals()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Models.BookRentals.BookRental>(SqlCommandBookRental.GetBookRentals);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Models.BookRentals.BookRental?> GetBookRentalById(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QuerySingleOrDefaultAsync<Models.BookRentals.BookRental>(SqlCommandBookRental.GetBookRentalById, new { Id = id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateBookRental(Models.BookRentals.BookRental bookRental)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandBookRental.CreateBookRental, bookRental) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateBookRental(Models.BookRentals.BookRental bookRental)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandBookRental.UpdateBookRental, bookRental) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteBookRental(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandBookRental.DeleteBookRental, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}
