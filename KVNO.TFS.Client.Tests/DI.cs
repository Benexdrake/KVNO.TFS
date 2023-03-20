using KVNO.TFS.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace KVNO.TFS.Client.Tests;

public class DI
{

    public async Task<IServiceProvider> Start()
    {
        var builder = new ConfigurationBuilder();
       
        IServiceCollection services = new ServiceCollection();

        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7011/") });

        services.AddScoped<CollectionService>();
        services.AddScoped<ProjectService>();
        services.AddScoped<WorkItemService>();
      
        

      
        
        return services.BuildServiceProvider();
    }
}
