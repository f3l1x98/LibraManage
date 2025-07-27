using Application.Books.CreateBook;
using Application.Books.GetBooks;
using Application.Books.LoanBook;
using AutoMapper;
using Carter;
using LibraManage.Dtos.Books;
using LibraManage.Dtos.Loans;
using MediatR;

namespace LibraManage.Endpoints;

public class BooksEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("books");

        group.MapGet("/", GetBooks);
        group.MapPost("/", CreateBook);
        group.MapPost("/{bookId}/loan", LoanBook);
    }

    private async Task<IResult> GetBooks(ISender sender, IMapper mapper)
    {
        var query = new GetBooksQuery();

        var result = await sender.Send(query);

        if (result.IsSuccess)
        {
            return TypedResults.Ok(mapper.Map<List<BookDto>>(result.Value));
        }
        else
        {
            // TODO probably sth better to return
            return TypedResults.BadRequest(result.Error.description);
        }
    }

    private async Task<IResult> CreateBook(CreateBookRequest request, ISender sender, IMapper mapper)
    {
        var command = new CreateBookCommand(request.Title, request.Description, request.ISBN);

        var result = await sender.Send(command);

        if (result.IsSuccess)
        {
            return TypedResults.Ok(mapper.Map<BookDto>(result.Value));
        }
        else
        {
            // TODO probably sth better to return
            return TypedResults.BadRequest(result.Error.description);
        }
    }

    private async Task<IResult> LoanBook(Guid bookId, LoanBookRequest request, ISender sender, IMapper mapper)
    {
        var command = new LoanBookCommand(new Domain.Members.MemberId(request.MemberId), new Domain.Books.BookId(bookId), 30);

        var result = await sender.Send(command);

        if (result.IsSuccess)
        {
            return TypedResults.Ok(mapper.Map<LoanDto>(result.Value));
        }
        else
        {
            // TODO probably sth better to return
            return TypedResults.BadRequest(result.Error.description);
        }
    }
}
