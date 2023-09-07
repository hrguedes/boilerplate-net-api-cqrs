using Micro.Erp.Application.Roles.Queries.Responses;
using Micro.Erp.Application.Users.Queries.Responses;

namespace Micro.Erp.Application.Users.Commands.responses;

public class UserAutenticated
{
    public UserResponse User { get; set; }
    public List<string> Roles { get; set; }
    public DateTime TokenExpires { get; set; }

    public string Token { get; set; }
    public UserAutenticated()
    {
        Roles = new List<string>();
    }
}