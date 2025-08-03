namespace LibraManage.Dtos.Loans;

public sealed class LoanBookRequest
{
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
}
