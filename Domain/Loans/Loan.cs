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
}
