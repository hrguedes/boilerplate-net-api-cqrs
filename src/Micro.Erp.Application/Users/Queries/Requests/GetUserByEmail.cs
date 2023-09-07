using MediatR;

namespace Micro.Erp.Application.Users.Queries.Requests;

public class GetUserByEmail : IRequest<Domain.User>
{
    public string Email { get; set; }
}