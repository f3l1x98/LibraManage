using CSharpFunctionalExtensions;

namespace Domain.Loans;
public interface ILoanRepository
{
    Task<List<Loan>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Maybe<Loan>> GetByIdAsync(LoanId id, CancellationToken cancellationToken);

    void Add(Loan book);
}
