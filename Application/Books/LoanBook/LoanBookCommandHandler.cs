using Application.Abstractions.Message;
using CSharpFunctionalExtensions;
using Domain;
using Domain.Books;
using Domain.Loans;
using Domain.Members;
using SharedKernel;

namespace Application.Books.LoanBook;
public sealed class LoanBookCommandHandler : ICommandHandler<LoanBookCommand, Loan>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ILoanRepository _loanRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LoanBookCommandHandler(IMemberRepository memberRepository, IBookRepository bookRepository, ILoanRepository loanRepository, IUnitOfWork unitOfWork)
    {
        _memberRepository = memberRepository;
        _bookRepository = bookRepository;
        _loanRepository = loanRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Loan, Error>> Handle(LoanBookCommand request, CancellationToken cancellationToken)
    {
        var memberResult = await _memberRepository.GetByIdAsync(request.MemberId, cancellationToken);
        if (memberResult.HasNoValue)
        {
            return Result.Failure<Loan, Error>(MemberErrors.NotFound(request.MemberId));
        }

        var bookResult = await _bookRepository.GetByIdAsync(request.BookId, cancellationToken);
        if (bookResult.HasNoValue)
        {
            return Result.Failure<Loan, Error>(BookErrors.NotFound(request.BookId));
        }

        Book book = bookResult.Value;
        bool loanPossible = book.LoanPossible();
        if (!loanPossible)
        {
            return Result.Failure<Loan, Error>(BookErrors.NoCopiesLeft(request.BookId));
        }

        var loanResult = Loan.create(book, memberResult.Value, request.durationInDays);
        if (loanResult.IsFailure)
        {
            return loanResult;
        }

        _loanRepository.Add(loanResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success<Loan, Error>(loanResult.Value);
    }
}
