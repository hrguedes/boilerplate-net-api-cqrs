using MediatR;
using Micro.Erp.Application.Roles.Queries.Requests;
using Micro.Erp.Application.Roles.Queries.Responses;
using Micro.Erp.Domain;
using Micro.Erp.Domain.IRepositories;
using Micro.Erp.Domain.Notifications;

namespace Micro.Erp.Application.Roles.QueryHandlers;

public class GetRolesByIdsHandler : IRequestHandler<GetRolesByIds, List<Role>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly NotificationContext _notificationContext;

    public GetRolesByIdsHandler(NotificationContext notificationContext, IRoleRepository roleRepository)
    {
        _notificationContext = notificationContext;
        _roleRepository = roleRepository;
    }

    public async Task<List<Role>> Handle(GetRolesByIds request, CancellationToken cancellationToken)
    {
        // Validate request
        if (request.Ids == null || request.Ids.Count == 0)
        {
            _notificationContext.AddNotification("Ids", "Invalid ids");
            return null;
        }
        
        // Get roles from database
        var roles = await _roleRepository.GetRolesByIds(request.Ids);
        return roles;
    }
}