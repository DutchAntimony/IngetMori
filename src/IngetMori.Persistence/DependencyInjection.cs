using IngetMori.Application.Common.Abstractions.Services;
using IngetMori.Domain.Common.Utilities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace IngetMori.Persistence;
public static class DependencyInjection
{
    private static SqliteConnection _sqliteConnection = null!;

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var appPath = AppContext.BaseDirectory;
        var dbName = configuration.GetValue<string>("DbName");
        Ensure.NotEmpty(dbName, nameof(dbName), "Data configuratie in app settings is onjuist, kan de DbName niet vinden");

        _sqliteConnection = new SqliteConnection(new SqliteConnectionStringBuilder()
        {
            DataSource = Path.Combine(appPath, dbName!)
        }.ToString());

        if (_sqliteConnection.State != ConnectionState.Open)
        {
            _sqliteConnection.Open();
        }

        services.AddDbContext<IngetMoriDbContext>(options => options.UseSqlite(_sqliteConnection));
        services.AddScoped<IDbContext, IngetMoriDbContext>();
        services.AddSingleton<IDbConnection>(_ => _sqliteConnection);

        return services;
    }

}
