using SharedKernel;

namespace Domain.Books;
public static class BookErrors
{
    public static Error NotFound(BookId bookId) => new("Books.NotFound", $"No Book found for id '{bookId.Value}'");
    public static Error NoCopiesLeft(BookId bookId) => new("Books.NoCopiesLeft", $"The Book with id '{bookId.Value}' has no copies left to be loaned");
}
