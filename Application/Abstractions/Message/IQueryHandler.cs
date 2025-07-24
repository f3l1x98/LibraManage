using CSharpFunctionalExtensions;
using MediatR;
using SharedKernel;

namespace Application.Abstractions.Message;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse, Error>> where TQuery : IQuery<TResponse>
{
}
