using Application.Abstractions.Message;
using Domain.Members;

namespace Application.Members.CreateMember;
public sealed record CreateMemberCommand(string FirstName, string LastName) : ICommand<Member>;