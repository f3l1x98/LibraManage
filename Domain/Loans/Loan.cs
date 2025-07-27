using CSharpFunctionalExtensions;
using Domain.Books;
using Domain.Members;
using Domain.Primitives;

namespace Domain.Loans;
public class Loan : BaseEntity<LoanId>
{
    public Book LoanedBook { get; set; }
    public Member Loaner { get; set; }
    public DateOnly LoanStartDate { get; set; }
    public DateOnly LoanEndDate { get; set; }

    public static Result<Loan> create(Book book, Member loaner, int durationInDays)
    {
        var loanResult = book.LoanBook();
        if (loanResult.IsFailure)
        {
            return Result.Failure<Loan>("Loans.OutOfCopies");
        }
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        return new Loan()
        {
            Id = new LoanId(Guid.NewGuid()),
            LoanedBook = book,
            Loaner = loaner,
            LoanStartDate = today,
            LoanEndDate = today.AddDays(durationInDays),
        };
    }
}
