using Application.Abstractions.Message;
using Domain.Loans;

namespace Application.Books.ReturnBook;
public sealed record ReturnBookCommand(LoanId LoanId) : ICommand<Loan>;
