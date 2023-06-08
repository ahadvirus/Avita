using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Avita.Commons.Contracts;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;

namespace Avita.Infrastructure.Extensions;

public static class ConfigureModulesExtension
{
    public static IMvcBuilder ConfigureModules(this IMvcBuilder builder)
    {
        builder.ConfigureApplicationPartManager(setupAction: manager =>
        {
            IEnumerable<Assembly> assemblies = Directory.GetFiles(path: AppDomain.CurrentDomain.BaseDirectory,
                    searchPattern: string.Format(format: "{0}*.dll", args: new object?[] { nameof(Avita) }))
                .Select(selector: file => Assembly.Load(assemblyRef: AssemblyName.GetAssemblyName(assemblyFile: file)));

            IEnumerable<AssemblyPart> parts = assemblies
                .SelectMany(selector: assembly =>  assembly.GetTypes())
                //.Where(predicate: type => type.IsClass && type.BaseType != null && type.BaseType == typeof(ControllerBase))
                .Where(predicate: TypePredicate)
                .Select(selector: type => new AssemblyPart(assembly: type.Assembly));
            
            //assemblies.Select(assembly => new AssemblyPart(assembly)).ToList();

            foreach (AssemblyPart part in parts)
            {
                manager.ApplicationParts.Add(part);
            }

        });
        
        return builder;
    }

    private static bool TypePredicate(Type entry)
    {
        bool result = false;

        if (entry.IsClass)
        {
            Type? moduleInterface = entry.GetInterface(name: nameof(IModule));
            Type? startupInterface = entry.GetInterface(name: nameof(IStartup));
            if (moduleInterface != null && startupInterface == null)
            {
                result = true;
            }
        }
        
        return result;
    }
}