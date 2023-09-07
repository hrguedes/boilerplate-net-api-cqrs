using Micro.Erp.Domain.Base;
using Micro.Erp.Domain.Childs;

namespace Micro.Erp.Domain;

public class Role : BaseAudity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ValueKey { get; set; }
    
    public virtual ICollection<UserRoles> UserRoles { get; set; }
}