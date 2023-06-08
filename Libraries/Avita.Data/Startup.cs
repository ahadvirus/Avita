using System;
using System.Reflection;
using Avita.Data.Mappings.Identity;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avita.Data;

public static class Startup
{
    public static void ConfigurationService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<Data.Connections.SqlServer>(implementationFactory: provider =>
            configuration.GetSection(
                    key: string.Format(
                        format: "{0}:{1}",
                        args: new object?[] { nameof(Data.Connections), nameof(Data.Connections.SqlServer) }
                        )
                    )
                .Get<Data.Connections.SqlServer>() ?? throw new Exception(message: string.Empty)
            );

        services.AddSingleton<Data.Connections.MasterSqlServer>(implementationFactory: provider =>
            configuration.GetSection(
                    key: string.Format(
                        format: "{0}:{1}",
                        args: new object?[] { nameof(Data.Connections), nameof(Data.Connections.MasterSqlServer) }
                    )
                )
                .Get<Data.Connections.MasterSqlServer>() ?? throw new Exception(message: string.Empty)
        );

        services.AddScoped<NHibernate.ISessionFactory>(implementationFactory: provider => FluentNHibernate.Cfg.Fluently
            .Configure()
            .Database(config: () => FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2012
                .ShowSql()
                .FormatSql()
                .ConnectionString(
                    connectionStringExpression: provider.GetService<Data.Connections.SqlServer>()!.ConnectionExpression
                )
            )
            .Mappings(mappings: mapping => mapping.FluentMappings.AddFromAssemblyOf<UserMapping>() )
            .BuildSessionFactory()
        );

        services.AddFluentMigratorCore()
            .ConfigureRunner(configure: builder => builder.AddSqlServer()
                .ScanIn(assemblies: new Assembly[]{typeof(Startup).Assembly}).For.All()
                .WithGlobalConnectionString(configureConnectionString: provider =>
                    provider.GetService<Data.Connections.SqlServer>()!.ConnectionString)
            );

        services.AddLogging(configure: builder => builder.AddFluentMigratorConsole());

        services.AddScoped<Data.Contracts.IMigratorService, Data.Services.MigrationService>();
    }
}
