using MediatR;
using Micro.Erp.Application.Users.Commands.responses;

namespace Micro.Erp.Application.Users.Commands.requests;

public class AutenticateUser : IRequest<UserAutenticated>
{
    public string Email { get; set; }
    public string Password { get; set; }
}