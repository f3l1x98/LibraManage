using CSharpFunctionalExtensions;

namespace Domain.Books;
public interface IBookRepository
{
    Task<List<Book>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Maybe<Book>> GetByIdAsync(BookId id, CancellationToken cancellationToken);

    void Add(Book book);
}
