using Domain.Books;
using Domain.Loans;
using Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;
public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).HasConversion(
            loanId => loanId.Value,
            value => new LoanId(value));

        builder
            .HasOne<Member>(s => s.Loaner)
            .WithMany(m => m.LoanedBooks)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<Book>(s => s.LoanedBook)
            .WithMany(b => b.LoanedCopies)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
