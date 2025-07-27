using SharedKernel;

namespace Domain.Members;
public static class MemberErrors
{
    public static Error NotFound(MemberId memberId) => new("Members.NotFound", $"No Member found for id '{memberId.Value}'");
}
