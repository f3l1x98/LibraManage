using CSharpFunctionalExtensions;
using MediatR;
using SharedKernel;

namespace Application.Abstractions.Message;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
{
}
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse, Error>> where TCommand : ICommand<TResponse>
{
}
