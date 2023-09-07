using MediatR;
using Micro.Erp.Application.Roles.Queries.Responses;
using Micro.Erp.Domain;

namespace Micro.Erp.Application.Roles.Queries.Requests;

public class GetRolesByIds : IRequest<List<Role>>
{
    public List<Guid> Ids { get; set; }
}