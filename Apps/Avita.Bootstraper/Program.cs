using Microsoft.AspNetCore.Builder;

namespace Avita.Bootstraper;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        Startup.ConfigurationService(builder.Services, builder.Configuration);

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        Startup.Configuration(app);

        app.Run();
    }
}