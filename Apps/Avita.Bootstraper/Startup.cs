using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avita.Bootstraper;

public static class Startup
{
    public static void ConfigurationService(IServiceCollection services, IConfiguration configuration)
    {

        //
        services.AddControllersWithViews()
            .ConfigureApplicationPartManager(setupAction: manager =>
                {
                    Assembly[] assemblies = new Assembly[] { };

                    IList<AssemblyPart> parts = assemblies.Select(assembly => new AssemblyPart(assembly)).ToList();

                    foreach (AssemblyPart part in parts)
                    {
                        manager.ApplicationParts.Add(part);
                    }

                });
    }

    public static void Configuration(WebApplication app)
    {

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}