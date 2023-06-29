using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Avita.Infrastructure.Utilities;

public static class File
{
    /// <summary>
    /// Return all assemblies name contains from directory address
    /// </summary>
    /// <param name="address"><see cref="string"/>The address of directory for searching dll files</param>
    /// <param name="assemblyName"><see cref="string"/>Name of assembly look for it (All assemblies name contains with it)</param>
    /// <returns></returns>
    public static IEnumerable<Assembly> GetAllAssemblies(string address, string assemblyName)
    {
        return Directory.GetFiles(path: address,
                searchPattern: string.Format(format: "{0}*.dll", args: new object?[] { assemblyName }))
            .Select(selector: file => Assembly.Load(assemblyRef: AssemblyName.GetAssemblyName(assemblyFile: file)));
    }
}