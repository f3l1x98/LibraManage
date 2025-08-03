using SharedKernel;

namespace Domain.Loans;
public static class LoanErrors
{
    public static Error NotFound(LoanId loanId) => new("Loans.NotFound", $"No Loan found for id '{loanId.Value}'");
}
