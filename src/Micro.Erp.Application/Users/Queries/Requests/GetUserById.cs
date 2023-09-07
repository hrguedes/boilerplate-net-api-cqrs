using MediatR;
using Micro.Erp.Application.Users.Queries.Responses;

namespace Micro.Erp.Application.Users.Queries.Requests;

public class GetUserById : IRequest<UserResponse>
{
    public Guid Id { get; set; }
}