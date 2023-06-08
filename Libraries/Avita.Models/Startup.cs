using Avita.Commons.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avita.Models;

public class Startup : IStartup
{
    public string Name
    {
        get
        {
            return nameof(Models);
        }
    }

    public void ConfigurationService(IServiceCollection services, IConfiguration configuration)
    {
        
    }
}
