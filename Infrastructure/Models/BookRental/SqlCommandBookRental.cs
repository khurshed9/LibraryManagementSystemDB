namespace LibraryManagementSystemDb.Infrastructure.Models.BookRentals;

public class SqlCommandBookRental
{
    public const string GetBookRentals = "SELECT * FROM bookRentals";
    
    public const string GetBookRentalById = "SELECT * FROM bookRentals WHERE id = @id";
    
    public const string CreateBookRental = "INSERT INTO bookRentals (id,bookId, userId, rentalDate, returnDate, createdAt) VALUES (@id,@bookId, @userId, @rentalDate, @returnDate, @createdAt)";
    
    public const string UpdateBookRental = "UPDATE bookRentals SET id = @id, bookId = @bookId, userId = @userId, rentalDate = @rentalDate, returnDate = @returnDate, createdAt = @createdAt WHERE id = @id";
    
    public const string DeleteBookRental = "DELETE FROM bookRentals WHERE id = @id";
}