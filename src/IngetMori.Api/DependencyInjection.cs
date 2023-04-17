using IngetMori.Domain.Common.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
}
