using Application.Books.CreateBook;
using Application.Books.GetBooks;
using AutoMapper;
using Carter;
using LibraManage.Dtos.Books;
using MediatR;

namespace LibraManage.Endpoints;

public class BooksEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("books");

        group.MapGet("/", GetBooks);
        group.MapPost("/", CreateBook);
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
            return TypedResults.BadRequest();
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
            return TypedResults.BadRequest();
        }
    }
}
