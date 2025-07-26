using Application.Abstractions.Message;
using Domain.Books;

namespace Application.Books.CreateBook;
public sealed record CreateBookCommand(string Title, string Descritpion, string ISBN) : ICommand<Book>;