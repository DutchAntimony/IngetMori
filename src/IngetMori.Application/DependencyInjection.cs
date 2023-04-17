using Microsoft.Extensions.DependencyInjection;
using IngetMori.Application.Common;

namespace IngetMori.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMessaging();

        return services;
    }
}
