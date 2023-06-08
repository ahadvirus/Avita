using Avita.Bootstraper.Infrastructure.Extensions;
using Avita.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Avita.Bootstraper;

public static class Startup
{
    public static void ConfigurationService(IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {

        services.AddInfrastructureService(environment: environment);
        
        services.AddControllersWithViews()
            .ConfigureModules();

        services.AddRouting(configureOptions: options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });
    }

    public static void Configuration(WebApplication app)
    {
        app.ApplyMigration();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}