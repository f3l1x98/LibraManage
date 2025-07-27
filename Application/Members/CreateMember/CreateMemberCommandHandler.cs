using Application.Abstractions.Message;
using CSharpFunctionalExtensions;
using Domain;
using Domain.Members;
using SharedKernel;

namespace Application.Members.CreateMember;
public sealed class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand, Member>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
    {
        _memberRepository = memberRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Member, Error>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var memberResult = Member.create(request.FirstName, request.LastName);
        if (memberResult.IsFailure)
        {
            return Result.Failure<Member, Error>(new Error("Members.create", "Failed to create Member"));
        }

        var member = memberResult.Value;
        _memberRepository.Add(member);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success<Member, Error>(member);
    }
}
