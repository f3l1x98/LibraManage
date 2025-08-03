using Application.Books.LoanBook;
using Application.Books.ReturnBook;
using AutoMapper;
using Carter;
using LibraManage.Dtos.Loans;
using LibraManage.Extensions;
using MediatR;

namespace LibraManage.Endpoints;

public class LoansEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("loans");

        group.MapPost("/", LoanBook);
        group.MapDelete("/{loanId}", ReturnBook);
    }

    private async Task<IResult> LoanBook(LoanBookRequest request, ISender sender, IMapper mapper)
    {
        var command = new LoanBookCommand(new Domain.Members.MemberId(request.MemberId), new Domain.Books.BookId(request.BookId), 30);

        var result = await sender.Send(command);

        return result.IsSuccess ? TypedResults.Ok(mapper.Map<LoanDto>(result.Value)) : result.ToProblemDetails();
    }

    private async Task<IResult> ReturnBook(Guid loanId, ISender sender, IMapper mapper)
    {
        var command = new ReturnBookCommand(new Domain.Loans.LoanId(loanId));

        var result = await sender.Send(command);

        return result.IsSuccess ? TypedResults.Ok(mapper.Map<LoanDto>(result.Value)) : result.ToProblemDetails();
    }
}
