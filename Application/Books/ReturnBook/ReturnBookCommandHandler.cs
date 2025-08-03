using Application.Abstractions.Message;
using CSharpFunctionalExtensions;
using Domain;
using Domain.Loans;
using SharedKernel;

namespace Application.Books.ReturnBook;
public sealed class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand, Loan>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReturnBookCommandHandler(ILoanRepository loanRepository, IUnitOfWork unitOfWork)
    {
        _loanRepository = loanRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Loan, Error>> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
    {
        var loanResult = await _loanRepository.GetByIdAsync(request.LoanId, cancellationToken);
        if (loanResult.HasNoValue)
        {
            return Result.Failure<Loan, Error>(LoanErrors.NotFound(request.LoanId));
        }

        _loanRepository.Remove(loanResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success<Loan, Error>(loanResult.Value);
    }
}
