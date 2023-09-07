using Micro.Erp.Domain.Base;
using Micro.Erp.Domain.Childs;

namespace Micro.Erp.Domain;

public class User : BaseAudity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid UserTypeId { get; set; }
    
    public virtual UserType UserType { get; set; }
    public virtual List<Role> Roles { get; set; }
    public virtual List<UserRoles> UserRoles { get; set; }
}