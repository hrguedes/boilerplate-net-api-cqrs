using Dapper;
using Micro.Erp.Domain;
using Micro.Erp.Domain.Childs;
using Micro.Erp.Domain.IRepositories;
using Micro.Erp.Infra.Data.Context;
using Micro.Erp.Infra.Data.Queries.System;

namespace Micro.Erp.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private DbSession _session;

    public UserRepository(DbSession session)
    {
        _session = session;
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _session.Connection.QueryFirstOrDefaultAsync<User>(AuthQueries.GetUserById, new { Id = id }, _session.Transaction);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _session.Connection.QueryFirstOrDefaultAsync<User>(AuthQueries.GetUserByEmail, new { Email = email }, _session.Transaction);
    }

    public async Task<UserType> GetUserTypeById(Guid userTypeId)
    {
        return await _session.Connection.QueryFirstOrDefaultAsync<UserType>(AuthQueries.GetUserTypeById, new { id = userTypeId }, _session.Transaction);
    }

    public async Task<List<UserRoles>> GetUserRolesByUserId(Guid userId)
    {
        var rows = await _session.Connection.QueryAsync<UserRoles>(AuthQueries.GetUserRolesByUserId, new { UserId = userId }, _session.Transaction);
        return rows.ToList();
    }
}