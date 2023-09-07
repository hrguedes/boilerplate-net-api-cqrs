using MediatR;
using Micro.Erp.Application.Users.Queries.Requests;
using Micro.Erp.Application.Users.Queries.Responses;
using Micro.Erp.Domain.IRepositories;
using Micro.Erp.Domain.Notifications;

namespace Micro.Erp.Application.Users.QueryHandlers;

public class GetUserByIdHandler : IRequestHandler<GetUserById, UserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly NotificationContext _notificationContext;

    public GetUserByIdHandler(IUserRepository userRepository, NotificationContext notificationContext, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _notificationContext = notificationContext;
        _roleRepository = roleRepository;
    }

    public async Task<UserResponse> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            _notificationContext.AddNotification("Id", "Id not found");
            return null;
        }
        var user = await _userRepository.GetUserById(request.Id);
        if (user == null)
        {
            _notificationContext.AddNotification("User", "User not found");
            return null;
        }
        var userRoles = await _userRepository.GetUserRolesByUserId(user.Id);
        var roles = await _roleRepository.GetRolesByIds(userRoles.Select(x => x.RoleId).ToList());
        user.UserType = await _userRepository.GetUserTypeById(user.UserTypeId);
        if (roles.Count > 0)
            user.Roles = roles;
        return new UserResponse()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            UserType = user.UserType.Name,
            Roles = user.Roles.Select(x => x.Name).ToList()
        };
    }
}