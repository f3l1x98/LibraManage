using CSharpFunctionalExtensions;
using SharedKernel;

namespace LibraManage.Extensions;

public static class ResultExtensions
{
    public static Microsoft.AspNetCore.Http.IResult ToProblemDetails<TValue>(this Result<TValue, Error> result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("Cannot convert Result.Success to ProblemDetails");
        }

        return Results.Problem(
        statusCode: StatusCodes.Status400BadRequest,
        title: "Bad request",
            extensions: new Dictionary<string, object?>
            {
                { "errors", new[] {result.Error } }
            });
    }
}
