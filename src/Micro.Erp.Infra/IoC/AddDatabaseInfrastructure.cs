using Micro.Erp.Domain.IRepositories;
using Micro.Erp.Infra.Data.Context;
using Micro.Erp.Infra.Data.Interfaces;
using Micro.Erp.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Micro.Erp.Infra.IoC;

public static class DataModuleDependecy
{
    public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<DbSession>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        return services;
    }
}