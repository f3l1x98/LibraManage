using Domain.Books;

namespace Persistence.Repositories;
public class BookRepository : Repository<Book, BookId>, IBookRepository
{
    public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
