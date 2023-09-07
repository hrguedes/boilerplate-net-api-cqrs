using Dapper;
using Micro.Erp.Domain;
using Micro.Erp.Domain.IRepositories;
using Micro.Erp.Infra.Data.Context;
using Micro.Erp.Infra.Data.Queries.System;

namespace Micro.Erp.Infra.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    private DbSession _session;

    public RoleRepository(DbSession session)
    {
        _session = session;
    }

    public async Task<List<Role>> GetRolesByIds(List<Guid> ids)
    {
        var rows = await _session.Connection.QueryAsync<Role>(AuthQueries.GetRolesByIds, new { Ids = ids }, _session.Transaction);
        return rows.ToList();
    }
}