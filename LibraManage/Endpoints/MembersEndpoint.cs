using Application.Members.CreateMember;
using AutoMapper;
using Carter;
using LibraManage.Dtos.Members;
using MediatR;

namespace LibraManage.Endpoints;

public class MembersEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("members");

        group.MapPost("/", CreateMember);
    }

    private async Task<IResult> CreateMember(CreateMemberRequest request, ISender sender, IMapper mapper)
    {
        var command = new CreateMemberCommand(request.FirstName, request.LastName);

        var result = await sender.Send(command);

        if (result.IsSuccess)
        {
            return TypedResults.Ok(mapper.Map<MemberDto>(result.Value));
        }
        else
        {
            // TODO probably sth better to return
            return TypedResults.BadRequest(result.Error.description);
        }
    }
}
