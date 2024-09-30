
namespace LibraryManagementSystemDb.Infrastructure.Services.BookRental;

public interface IBookRentalService
{
    Task<IEnumerable<Models.BookRentals.BookRental>> GetBookRentals();
    
    Task<Models.BookRentals.BookRental?> GetBookRentalById(Guid id);
    
    Task<bool> CreateBookRental(Models.BookRentals.BookRental bookRental);
    
    Task<bool> UpdateBookRental(Models.BookRentals.BookRental bookRental);
    
    Task<bool> DeleteBookRental(Guid id);
}