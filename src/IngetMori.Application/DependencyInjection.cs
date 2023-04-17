using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using IngetMori.Application.Common.Behaviours;
using MediatR;
using System.Reflection;

namespace IngetMori.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMessaging();

        return services;
    }

    private static void AddMessaging(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
    }
}
