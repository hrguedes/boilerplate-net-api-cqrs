using MediatR;
using Micro.Erp.Application.Users.Commands.requests;
using Micro.Erp.Application.Users.Commands.responses;
using Micro.Erp.Application.Users.Queries.Requests;
using Micro.Erp.Domain;
using Micro.Erp.Domain.Notifications;

namespace Micro.Erp.Application.Users.CommandHandlers;

public class AutenticateUserHandler : IRequestHandler<AutenticateUser, UserAutenticated>
{
    private readonly IMediator _mediator;
    private readonly NotificationContext _notificationContext;

    public AutenticateUserHandler(IMediator mediator, NotificationContext notificationContext)
    {
        _mediator = mediator;
        _notificationContext = notificationContext;
    }

    public async Task<UserAutenticated> Handle(AutenticateUser request, CancellationToken cancellationToken)
    {
        // Validate request
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            _notificationContext.AddNotification("Email", "Invalid user or password");
            return null;
        }
        
        // get user
        var user = await _mediator.Send(new GetUserByEmail()
        {
            Email = request.Email
        });

        if (_notificationContext.HasNotifications)
            return null;
        
        // user has roles?
        if (user.Roles.Count == 0)
        {
            _notificationContext.AddNotification("Roles", "User is not authorize");
            return null;
        }
        
        // password is valid?
        if (request.Password != user.Password)
        {
            _notificationContext.AddNotification("Password", "Invalid user or password");
             return null;
        }

        return GenerateResponse(user);
    }

    private UserAutenticated GenerateResponse(User user)
    {
        return new UserAutenticated
        {
            User = new ()
            {
                Email = user.Email,
                Name = user.Name,
                Id = user.Id,
                UserType = user.UserType.Name
            },
            Roles = user.Roles.Select(x => x.ValueKey).ToList(),
            TokenExpires = DateTime.UtcNow.AddHours(1),
            Token = ""
        };
    }
}