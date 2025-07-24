using CSharpFunctionalExtensions;

namespace Domain.Books;
public interface IBookRepository
{
    Task<Maybe<Book>> GetByIdAsync(BookId id, CancellationToken cancellationToken);

    void Add(Book book);
}
