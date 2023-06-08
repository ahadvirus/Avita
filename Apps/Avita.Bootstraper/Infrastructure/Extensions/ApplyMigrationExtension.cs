using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Avita.Bootstraper.Infrastructure.Extensions;

public static class ApplyMigrationExtension
{

    public static async void ApplyMigration(this WebApplication app)
    {
        using (IServiceScope scope = app.Services.CreateScope())
        {
            Data.Contracts.IMigratorService?
                service = scope.ServiceProvider.GetService<Data.Contracts.IMigratorService>();

            if (service != null)
            {
                await service.MigrateUp();
            }
        }
    }
}