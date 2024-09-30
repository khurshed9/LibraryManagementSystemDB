namespace LibraryManagementSystemDb.Infrastructure.Models.BookRentals.BookRentalQueries;

public class GetRentalBookByUser
{
    public Guid BookRentalId { get; set; }

    public Guid BookId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime RentalDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public DateTime CreatedAt { get; set; }
}