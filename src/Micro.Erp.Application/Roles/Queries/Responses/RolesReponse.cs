namespace Micro.Erp.Application.Roles.Queries.Responses;

public class RolesReponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ValueKey { get; set; }
    public bool RegisterActive { get; set; }
}