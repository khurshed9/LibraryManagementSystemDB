using LibraryManagementSystemDb.Infrastructure.Models.Book.BookQueries;
using LibraryManagementSystemDb.Infrastructure.Services.AuthorService;
using LibraryManagementSystemDb.Infrastructure.Services.BookRental;
using LibraryManagementSystemDb.Infrastructure.Services.BookRental.BookQueriesService;
using LibraryManagementSystemDb.Infrastructure.Services.BookRental.BookRentalQueriesService;
using LibraryManagementSystemDb.Infrastructure.Services.BookService;
using LibraryManagementSystemDb.Infrastructure.Services.CategoryService;
using LibraryManagementSystemDb.Infrastructure.Services.UserService;

namespace LibraryManagementSystemDb.ExtensionMethods;

public static class AddRegisterService
{
    public static void AddService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IUserService, UserService>();
        serviceCollection.AddTransient<IAuthorService, AuthorService>();
        serviceCollection.AddTransient<ICategoryService, CategoryService>();
        serviceCollection.AddTransient<IBookService, BookService>();
        serviceCollection.AddTransient<IBookRentalService, BookRentalService>();
        serviceCollection.AddSingleton<GetBookWithAuthorCategoryService>();
        serviceCollection.AddTransient<GetBookPublishedDateService>();
        serviceCollection.AddTransient<GetBookByAuthorCategoryService>();
        serviceCollection.AddTransient<GetRentalBookByUserService>();
    }
}