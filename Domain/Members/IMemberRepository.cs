using CSharpFunctionalExtensions;

namespace Domain.Members;
public interface IMemberRepository
{
    Task<List<Member>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Maybe<Member>> GetByIdAsync(MemberId id, CancellationToken cancellationToken);

    void Add(Member book);
}
