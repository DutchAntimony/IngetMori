using IngetMori.Api.Middleware;
using IngetMori.Domain.Common.Utilities;
using IngetMori.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IngetMori.Api;

internal static class ApplicationBuilderExtensions
{
    internal static async Task Configure(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.ConfigureSwagger();
        }

        app.UseCustomExceptionHandler();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        await MigrateDatabase(app);
    }

    private static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        return app;
    }

    private static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "IngetMori leden administratie Api"));
        return app;
    }

    private static async Task MigrateDatabase(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        using var dbContext = scope.ServiceProvider.GetService<IngetMoriDbContext>();
        Ensure.NotNull(dbContext, "Het is niet gelukt om de database te laden uit dependency injection.", nameof(dbContext));
        await dbContext!.Database.MigrateAsync();
    }
}
