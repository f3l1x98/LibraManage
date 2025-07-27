using Domain.Loans;

namespace Persistence.Repositories;
public sealed class LoanRepository : Repository<Loan, LoanId>, ILoanRepository
{
    public LoanRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
