using Microsoft.Extensions.DependencyInjection;
using Micro.Erp.Application.Users.QueryHandlers;
using Micro.Erp.Domain.Notifications;

namespace Micro.Erp.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // handlers
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(GetUserByLoginHandler).Assembly);
        });
        
        // Fluent Validation
        services.AddScoped<NotificationContext>();

        // return
        return services;
    }
}