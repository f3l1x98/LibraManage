using Application.Abstractions.Message;
using CSharpFunctionalExtensions;
using Domain.Books;
using SharedKernel;

namespace Application.Books.GetBooks;
public sealed class GetBooksQueryHandler : IQueryHandler<GetBooksQuery, List<Book>>
{
    private readonly IBookRepository _bookRepository;

    public GetBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Result<List<Book>, Error>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync(cancellationToken);

        return Result.Success<List<Book>, Error>(books);
    }
}
