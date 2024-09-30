using Dapper;
using Npgsql;
using LibraryManagementSystemDb.Infrastructure.Models.BookRentals.BookRentalQueries;

namespace LibraryManagementSystemDb.Infrastructure.Services.BookRental.BookRentalQueriesService;

public class GetRentalBookByUserService
{
    public async Task<IEnumerable<GetRentalBookByUser>> GetRentalBookByUser(Guid userId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionDb.ConnectionStringC.ConnectionStringP))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetRentalBookByUser>(SqlCommand.Get, new { userid = @userId });
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
    public const string Get = @"select br.id as rentalId, b.id as bookId, b.title, br.RentalDate, br.ReturnDate, br.CreatedAt from bookrentals br
                               join books b on b.id = br.bookId
                               where br.userid = @userId";
}