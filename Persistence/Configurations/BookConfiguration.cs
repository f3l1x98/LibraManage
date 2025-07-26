using Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasConversion(
            bookId => bookId.Value,
            value => new BookId(value));

        builder.Property(b => b.Title)
            .IsRequired();

        builder
            .HasIndex(b => b.Title)
            .IsUnique();

        builder.Property(b => b.ISBN)
            .IsRequired();

        builder
            .HasIndex(b => b.ISBN)
            .IsUnique();
    }
}
