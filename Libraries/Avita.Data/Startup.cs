using System;
using System.Reflection;
using Avita.Commons.Contracts;
using Avita.Data.Mappings.Identity;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avita.Data;

public class Startup : IStartup
{
    public string Name
    {
        get
        {
            return nameof(Data);
        }
    }

    public void ConfigurationService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<Connections.SqlServer>(implementationFactory: provider =>
            configuration.GetSection(
                    key: string.Format(
                        format: "{0}:{1}",
                        args: new object?[] { nameof(Connections), nameof(Connections.SqlServer) }
                        )
                    )
                .Get<Connections.SqlServer>() ?? throw new Exception(message: string.Empty)
            );

        services.AddSingleton<Connections.MasterSqlServer>(implementationFactory: provider =>
            configuration.GetSection(
                    key: string.Format(
                        format: "{0}:{1}",
                        args: new object?[] { nameof(Connections), nameof(Connections.MasterSqlServer) }
                    )
                )
                .Get<Connections.MasterSqlServer>() ?? throw new Exception(message: string.Empty)
        );

        services.AddScoped<NHibernate.ISessionFactory>(implementationFactory: provider => FluentNHibernate.Cfg.Fluently
            .Configure()
            .Database(config: () => FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2012
                .ShowSql()
                .FormatSql()
                .ConnectionString(
                    connectionStringExpression: provider.GetService<Connections.SqlServer>()!.ConnectionExpression
                )
            )
            .Mappings(mappings: mapping => mapping.FluentMappings.AddFromAssemblyOf<UserMapping>() )
            .BuildSessionFactory()
        );

        services.AddFluentMigratorCore()
            .ConfigureRunner(configure: builder => builder.AddSqlServer()
                .ScanIn(assemblies: new Assembly[]{typeof(Startup).Assembly}).For.All()
                .WithGlobalConnectionString(configureConnectionString: provider =>
                    provider.GetService<Connections.SqlServer>()!.ConnectionString)
            );

        services.AddLogging(configure: builder => builder.AddFluentMigratorConsole());

        services.AddScoped<Contracts.IMigratorService, Services.MigrationService>();
    }
}
