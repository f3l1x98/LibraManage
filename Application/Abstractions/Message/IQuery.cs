using CSharpFunctionalExtensions;
using MediatR;
using SharedKernel;

namespace Application.Abstractions.Message;
public interface IQuery<TResponse> : IRequest<Result<TResponse, Error>>
{
}
