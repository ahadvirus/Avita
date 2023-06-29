using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Avita.Commons.Contracts;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Avita.Infrastructure.Extensions;

public static class AddCompileModulesViewsExtension
{
    public static IServiceCollection AddCompileModulesViews(this IServiceCollection services)
    {
        IEnumerable<Assembly> assemblies = Utilities.File.GetAllAssemblies(
            address: AppDomain.CurrentDomain.BaseDirectory,
            assemblyName: nameof(Avita)
        );

        IEnumerable<Assembly> parts = assemblies
            .SelectMany(selector: assembly => assembly.GetTypes())
            //.Where(predicate: type => type.IsClass && type.BaseType != null && type.BaseType == typeof(ControllerBase))
            .Where(predicate: type =>
                type.IsClass && type.GetInterface(name: nameof(IModule)) != null &&
                type.GetInterface(name: nameof(IStartup)) == null)
            .Select(selector: type => type.Assembly);

        services.Configure<MvcRazorRuntimeCompilationOptions>(configureOptions: options =>
        {
            foreach (Assembly assembly in parts)
            {
                options.FileProviders.Add(item: new EmbeddedFileProvider(assembly: assembly));
            }
        });

        return services;
    }
}