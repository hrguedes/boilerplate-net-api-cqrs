using System.Data;
using Dapper;
using Micro.Erp.Utils;
using Microsoft.Data.SqlClient;

namespace Micro.Erp.Infra.Data.Context;

public sealed class DbSession : IDisposable
{
    private Guid _id;
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; set; }

    public DbSession()
    {
        _id = Guid.NewGuid();
        Connection = new SqlConnection(Settings.ConnectionString);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}