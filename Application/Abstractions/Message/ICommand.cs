using CSharpFunctionalExtensions;
using MediatR;
using SharedKernel;

namespace Application.Abstractions.Message;

public interface ICommand : IRequest, ICommandBase
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse, Error>>, ICommandBase
{
}

public interface ICommandBase
{
}
