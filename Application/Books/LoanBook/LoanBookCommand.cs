using Application.Abstractions.Message;
using Domain.Books;
using Domain.Loans;
using Domain.Members;

namespace Application.Books.LoanBook;
public record LoanBookCommand(MemberId MemberId, BookId BookId, int durationInDays) : ICommand<Loan>;