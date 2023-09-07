using MediatR;
using Micro.Erp.Application.Roles.Queries.Requests;
using Micro.Erp.Application.Users.Queries.Requests;
using Micro.Erp.Domain;
using Micro.Erp.Domain.IRepositories;
using Micro.Erp.Domain.Notifications;

namespace Micro.Erp.Application.Users.QueryHandlers;

public class GetUserByLoginHandler : IRequestHandler<GetUserByEmail, User>
{
    private readonly IUserRepository _userRepository;
    private readonly IMediator _mediator;
    private readonly NotificationContext _notificationContext;

    public GetUserByLoginHandler(NotificationContext notificationContext, IUserRepository userRepository, IMediator mediator)
    {
        _notificationContext = notificationContext;
        _userRepository = userRepository;
        _mediator = mediator;
    }

    public async Task<User> Handle(GetUserByEmail request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(request.Email);
        if (user == null)
        {
            _notificationContext.AddNotification("User", "User not found");
            return null;
        }
        
        var userRoles = await _userRepository.GetUserRolesByUserId(user.Id);
        if (userRoles.Count <= 0) return user;
        user.UserRoles = userRoles;
        var roles = await _mediator.Send(new GetRolesByIds()
        {
            Ids = user.UserRoles.Select(x => x.RoleId).ToList()
        });
        user.UserType = await _userRepository.GetUserTypeById(user.UserTypeId);
        if (roles.Count > 0)
            user.Roles = roles;
        return user;
    }
}