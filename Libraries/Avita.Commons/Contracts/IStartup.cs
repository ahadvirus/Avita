using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avita.Commons.Contracts;

public interface IStartup : IModule
{
    
    void ConfigurationService(IServiceCollection services, IConfiguration configuration);
}