using IngetMori.Domain.Common.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace IngetMori.Api;

internal static class DependencyInjection
{
    internal static IServiceCollection AddFirebaseAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var appName = configuration.GetValue<string>("FirebaseProjectName");
        Ensure.NotEmpty(appName, "Firebase configuratie in app settings is onjuist, kan de appName niet vinden.", nameof(appName));
        appName = appName!.ToLower();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://securetoken.google.com/{appName}";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = $"https://securetoken.google.com/{appName}",
                    ValidateAudience = true,
                    ValidAudience = appName,
                    ValidateLifetime = true
                };
            });

        services.AddAuthorization();

        return services;
    }

    internal static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Inget mori leden administratie API",
                Version = "v1"
            }));

        return services;
    }
}
