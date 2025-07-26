using Domain.Loans;
using Domain.Primitives;

namespace Domain.Members;
public class Member : BaseEntity<MemberId>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Loan> LoanedBooks { get; set; }
}
