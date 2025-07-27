using CSharpFunctionalExtensions;
using Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;
public class BookRepository : Repository<Book, BookId>, IBookRepository
{
    public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override Task<Maybe<Book>> GetByIdAsync(BookId id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<Book>()
            .Include(b => b.LoanedCopies)
            .SingleOrDefaultAsync(e => e.Id == id, cancellationToken)
            .AsMaybe();
    }

    public virtual Task<List<Book>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<Book>()
            .Include(b => b.LoanedCopies)
            .ToListAsync(cancellationToken);
    }
}
