using LibraryManagementSystemDb.ExtensionMethods;
using LibraryManagementSystemDb.Infrastructure.Models.Author;
using LibraryManagementSystemDb.Infrastructure.Models.Book;
using LibraryManagementSystemDb.Infrastructure.Models.Book.BookQueries;
using LibraryManagementSystemDb.Infrastructure.Models.BookRentals;
using LibraryManagementSystemDb.Infrastructure.Models.Category;
using LibraryManagementSystemDb.Infrastructure.Models.User;
using LibraryManagementSystemDb.Infrastructure.Services.AuthorService;
using LibraryManagementSystemDb.Infrastructure.Services.BookRental;
using LibraryManagementSystemDb.Infrastructure.Services.BookRental.BookQueriesService;
using LibraryManagementSystemDb.Infrastructure.Services.BookRental.BookRentalQueriesService;
using LibraryManagementSystemDb.Infrastructure.Services.BookService;
using LibraryManagementSystemDb.Infrastructure.Services.CategoryService;
using LibraryManagementSystemDb.Infrastructure.Services.UserService;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5131/");

builder.WebHost.ConfigureKestrel(options => { options.AllowSynchronousIO = true; });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddService();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/api/users",async ([FromServices]IUserService userService) =>
{
    return await userService.GetUsers();
});

app.MapGet("/api/users/{id}", async ([FromServices]IUserService userService, Guid id) =>
{
    return await userService.GetUserById(id);
});

app.MapPost("api/users", async ([FromServices]IUserService userService, User user) =>
{
    return await userService.CreateUser(user);
});

app.MapPut("api/users", async ([FromServices]IUserService userService, User user) =>
{
    return await userService.UpdateUser(user);
});

app.MapDelete("api/users/{id}", async ([FromServices]IUserService userService, Guid id) =>
{
    return await userService.DeleteUser(id);
});


////////////////////////////////Author////////////////////////////////


app.MapGet("/api/authors", async ([FromServices]IAuthorService authorService) =>
{
    return await authorService.GetAuthors();
});

app.MapGet("/api/authors/{id}", async ([FromServices]IAuthorService authorService, Guid id) =>
{
    return await authorService.GetAuthorById(id);
});

app.MapPost("/api/authors", async ([FromServices]IAuthorService authorService, Author author) =>
{
    return await authorService.CreateAuthor(author);
});

app.MapPut("/api/authors", async ([FromServices]IAuthorService authorService, Author author) =>
{
    return await authorService.UpdateAuthor(author);
});

app.MapDelete("/api/authors/{id}", async ([FromServices]IAuthorService authorService, Guid id) =>
{
    return await authorService.DeleteAuthor(id);
});


/////////////////////////////////////Category////////////////////////////////


app.MapGet("/api/categories", async ([FromServices]ICategoryService categoryService) =>
{
    return await categoryService.GetCategories();
});

app.MapGet("/api/categories/{id}", async ([FromServices]ICategoryService categoryService, Guid id) =>
{
    return await categoryService.GetCategoryById(id);
});

app.MapPost("/api/categories", async ([FromServices]ICategoryService categoryService, Category category) =>
{
    return await categoryService.CreateCategory(category);
});

app.MapPut("/api/categories", async ([FromServices]ICategoryService categoryService, Category category) =>
{
    return await categoryService.UpdateCategory(category);
});

app.MapDelete("/api/categories/{id}", async ([FromServices]ICategoryService categoryService, Guid id) =>
{
    return await categoryService.DeleteCategory(id);
});


////////////////////////////////Book////////////////////////////////

app.MapGet("api/books", async ([FromServices] IBookService bookService) =>
{
    return await bookService.GetBooks();
});

app.MapGet("/api/books/{id}", async ([FromServices] IBookService bookService, Guid id) =>
{
    return await bookService.GetBookById(id);
});

app.MapPost("/api/books", async ([FromServices] IBookService bookService, Book book) =>
{
    return await bookService.CreateBook(book);
});

app.MapPut("/api/books", async ([FromServices] IBookService bookService, Book book) =>
{
    return await bookService.UpdateBook(book);
});

app.MapDelete("/api/books/{id}", async ([FromServices] IBookService bookService, Guid id) =>
{
    return await bookService.DeleteBook(id);
});


///////////////////////////////////////BookRental////////////////////////////////


app.MapGet("/api/bookrentals", async ([FromServices] IBookRentalService bookRentalService) =>
{
    return await bookRentalService.GetBookRentals();
});

app.MapGet("/api/bookrentals/{id}", async ([FromServices] IBookRentalService bookRentalService, Guid id) =>
{
    return await bookRentalService.GetBookRentalById(id);
});

app.MapPost("/api/bookrentals", async ([FromServices] IBookRentalService bookRentalService, BookRental bookRental) =>
{
    return await bookRentalService.CreateBookRental(bookRental);
});

app.MapPut("/api/bookrentals", async ([FromServices] IBookRentalService bookRentalService, BookRental bookRental) =>
{
    return await bookRentalService.UpdateBookRental(bookRental);
});

app.MapDelete("/api/bookrentals/{id}", async ([FromServices] IBookRentalService bookRentalService, Guid id) =>
{
    return await bookRentalService.DeleteBookRental(id);
});



/////////////////////////////////////////Get books by author and category////////////////////////////////


app.MapGet("/api/bookByAuthorCategory", async ([FromServices]GetBookWithAuthorCategoryService getBookByAuthorCategory) =>
{
    return await getBookByAuthorCategory.GetBookWithAuthorCategory();
});


/////////////////////////////////////////Get books published in 5 year //////////////////////////////////


app.MapGet("/api/bookPublishedDate", async ([FromServices] GetBookPublishedDateService getBookPublishedDate) =>
{
    return await getBookPublishedDate.GetBookPublishedDate5();
});


/////////////////////////////////////////Get book by author and category id////////////////////////////////


app.MapGet("/api/bookByAuthorCategoryId/{authorId}/{categoryId}", async (
    [FromServices] GetBookByAuthorCategoryService getBookByAuthorCategoryId, Guid authorId, Guid categoryId) =>
{
    return await getBookByAuthorCategoryId.GetBookByAuthorCategories(authorId, categoryId);
});


/////////////////////////////////////////Get book by rental status and user id////////////////////////////////


app.MapGet("/api/bookByRentalStatusUserId/{userId}", async (
    [FromServices] GetRentalBookByUserService getRentalBookByUserService, Guid userId) =>
{
    return await getRentalBookByUserService.GetRentalBookByUser(userId);
});

app.Run();
