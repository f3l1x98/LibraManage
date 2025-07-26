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
            .HasOne<Member>(m => m.Loaner)
            .WithMany(s => s.LoanedBooks)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
