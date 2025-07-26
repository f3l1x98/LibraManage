using Application.Abstractions.Message;
using CSharpFunctionalExtensions;
using Domain;
using Domain.Books;
using MediatR;
using SharedKernel;

namespace Application.Books.CreateBook;
public sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, Book>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    async Task<Result<Book, Error>> IRequestHandler<CreateBookCommand, Result<Book, Error>>.Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var createResult = Book.create(request.Title, request.Descritpion, request.ISBN);

        if (createResult.IsFailure)
        {
            return Result.Failure<Book, Error>(new Error("Books.create", "Failed to create Book"));
        }

        _bookRepository.Add(createResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success<Book, Error>(createResult.Value);
    }
}
