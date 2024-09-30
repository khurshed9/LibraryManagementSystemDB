namespace LibraryManagementSystemDb.Infrastructure.Models.Book.BookQueries;

public class GetBookWithAuthorCategory
{
    public Guid BookId { get; set; }

    public string? Title { get; set; }

    public string? AuthorName { get; set; }
    
    public DateTime AuthorDateOfBirth { get; set; }

    public string? AuthorBiography { get; set; }

    public string? CategoryName { get; set; }
    
}

