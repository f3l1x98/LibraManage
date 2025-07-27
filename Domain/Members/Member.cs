using CSharpFunctionalExtensions;
using Domain.Loans;
using Domain.Primitives;

namespace Domain.Members;
public class Member : BaseEntity<MemberId>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Loan> LoanedBooks { get; set; }

    public static Result<Member> create(string FirstName, string LastName)
    {
        return Result.Success<Member>(new Member()
        {
            Id = new MemberId(Guid.NewGuid()),
            FirstName = FirstName,
            LastName = LastName,
        });
    }
}
