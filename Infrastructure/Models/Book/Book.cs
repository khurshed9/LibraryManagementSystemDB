namespace LibraryManagementSystemDb.Infrastructure.Models.Book;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ISBN { get; set; } = null!;

    public DateTime PublishedDate { get; set; }

    public Guid AuthorId { get; set; }

    public Guid CategoryId { get; set; }

    public DateTime CreatedAt { get; set; }
}