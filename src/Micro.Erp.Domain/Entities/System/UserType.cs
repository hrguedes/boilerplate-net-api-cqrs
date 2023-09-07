using Micro.Erp.Domain.Base;

namespace Micro.Erp.Domain;

public class UserType : BaseAudity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ValueKey { get; set; }
}