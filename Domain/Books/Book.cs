using CSharpFunctionalExtensions;
using Domain.Loans;
using Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Books;
public class Book : BaseEntity<BookId>
{
    public string Title { get; private set; }

    public string Summary { get; private set; }

    public string ISBN { get; private set; }

    [Range(1, int.MaxValue)]
    public int NumberOfCopies { get; private set; }

    // TODO authors, #inLibrary, #loaned, ...

    public List<Loan> LoanedCopies { get; private set; }

    public int NumberOfLoanedCopies
    {
        get
        {
            return LoanedCopies?.Count ?? 0;
        }
    }

    public static Result<Book> create(string title, string summary, string isbn)
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


    internal Result LoanBook()
    {
        if (NumberOfCopies == 0)
        {
            return Result.Failure("All copies loaned");
        }
        NumberOfCopies--;
        return Result.Success();
    }

    internal Result ReturnBook()
    {
        NumberOfCopies++;
        return Result.Success();
    }
}
