using Micro.Erp.Domain.Childs;

namespace Micro.Erp.Domain.IRepositories;

public interface IUserRepository
{
    Task<User> GetUserById(Guid id);
    Task<User> GetUserByEmail(string email);
    Task<UserType> GetUserTypeById(Guid userTypeId);
    Task<List<UserRoles>> GetUserRolesByUserId(Guid userId);
}