using Application.Abstractions.Message;
using Domain.Books;

namespace Application.Books.GetBooks;
public sealed record GetBooksQuery : IQuery<List<Book>>;
