using IngetMori.Application.Common.Abstractions.Services;
using IngetMori.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IngetMori.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

}
