using CSharpFunctionalExtensions;
using Domain.Primitives;

namespace Domain.Books;
public class Book : BaseEntity<BookId>
{
    public String Title { get; private set; }

    public String Summary { get; private set; }

    public String ISBN { get; private set; }

    // TODO authors, #inLibrary, #loaned, ...

    public static Result<Book> create(String title, String summary, String isbn)
    {
        var book = new Book()
        {
            Id = new BookId(Guid.NewGuid()),
            Title = title,
            Summary = summary,
            ISBN = isbn,
        };

        return Result.Success(book);
    }

    // TODO method for loaning and returning (perhaps that should be part of Member?!?!?)
}
