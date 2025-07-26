using Application.Books.GetBooks;
using Carter;
using MediatR;

namespace LibraManage.Endpoints;

public class BooksEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("books");

        group.MapGet("/", GetBooks);
    }

    private async Task<IResult> GetBooks(ISender sender)
    {
        var query = new GetBooksQuery();

        var result = await sender.Send(query);

        if (result.IsSuccess)
        {

            return TypedResults.Ok(result.Value);
        }
        else
        {
            // TODO probably sth better to return
            return TypedResults.BadRequest();
        }
    }
}
