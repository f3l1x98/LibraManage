using Domain.Books;
using Domain.Loans;
using Domain.Members;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }

    public DbSet<Member> Members { get; set; }

    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
