namespace Micro.Erp.Domain.IRepositories;

public interface IRoleRepository
{
    Task<List<Role>> GetRolesByIds(List<Guid> ids);
}