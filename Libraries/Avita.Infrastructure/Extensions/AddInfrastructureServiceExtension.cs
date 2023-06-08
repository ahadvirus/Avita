using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Avita.Commons.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Avita.Infrastructure.Extensions;

public static class AddInfrastructureServiceExtension
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection entry,
        IHostEnvironment environment)
    {
        /*
        IDictionary<string, IStartup> startups =
            new Dictionary<string, IStartup>(
                collection: new KeyValuePair<string, IStartup>[]
                {
                    new KeyValuePair<string, IStartup>(nameof(Data), new Data.Startup()),
                    new KeyValuePair<string, IStartup>(nameof(Models), new Models.Startup())
                }
            );
        */

        IEnumerable<Assembly> assemblies = Directory.GetFiles(path: AppDomain.CurrentDomain.BaseDirectory,
                searchPattern: string.Format(format: "{0}*.dll", args: new object?[] { nameof(Avita) }))
            .Select(selector: file => Assembly.Load(assemblyRef: AssemblyName.GetAssemblyName(assemblyFile: file)));

        IEnumerable<Type> types = assemblies
                .SelectMany(selector: assembly => assembly.GetTypes())
                .Where(predicate: type =>
                    type.IsClass && typeof(IStartup).IsAssignableFrom(type));

        foreach (Type type in types)
        {
            IStartup? startup = (IStartup?)Activator.CreateInstance(type: type);
            if (startup != null)
            {
                string configurationName =
                    string.Format(format: "{0}settings", args: new object?[] { startup.Name.ToLower() });

                string environmentConfigurationName = string.Format(format: "{0}.{1}",
                    args: new object?[] { configurationName, environment.EnvironmentName });
                // TODO: Checking files is exists
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                    .AddJsonFile(
                        path: string.Format(format: "{0}.json", args: new object?[] { configurationName })
                    )
                    .AddJsonFile(
                        path: string.Format(format: "{0}.json", args: new object?[] { environmentConfigurationName }),
                        optional: true
                    );
                
                startup.ConfigurationService(services: entry, configuration: configurationBuilder.Build());
            }
        }

        return entry;
    }
}