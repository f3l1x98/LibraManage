using Domain.Members;

namespace Persistence.Repositories;
public sealed class MemberRepository : Repository<Member, MemberId>, IMemberRepository
{
    public MemberRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
