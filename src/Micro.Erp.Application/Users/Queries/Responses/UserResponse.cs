using Micro.Erp.Application.Roles.Queries.Responses;

namespace Micro.Erp.Application.Users.Queries.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string UserType { get; set; }
    public List<string> Roles { get; set; }
}