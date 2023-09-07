using Micro.Erp.Domain.Base;

namespace Micro.Erp.Domain.Childs;

public class UserRoles : BaseAudity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}