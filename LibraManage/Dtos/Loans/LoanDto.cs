using LibraManage.Dtos.Books;
using LibraManage.Dtos.Members;

namespace LibraManage.Dtos.Loans;

public sealed class LoanDto : BaseDto
{
    public BookDto LoanedBook { get; set; }
    public MemberDto Loaner { get; set; }
    public DateOnly LoanStartDate { get; set; }
    public DateOnly LoanEndDate { get; set; }
}
