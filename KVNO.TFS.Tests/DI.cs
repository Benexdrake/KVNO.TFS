using KVNO.TFS.Server.Data;
using KVNO.TFS.Server.DL;
using KVNO.TFS.Server.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace KVNO.TFS.Server.Tests;

public class DI
{

    public async Task<IServiceProvider> Start()
    {
        var builder = new ConfigurationBuilder();
        BuildConfig(builder);
        IConfiguration conf = builder.Build();
        IServiceCollection services = new ServiceCollection();

        services.AddScoped<ICollectionLogic, CollectionLogic>();
        services.AddScoped<IProjectLogic, ProjectLogic>();
        services.AddScoped<IWorkItemLogic, WorkItemLogic>();
        services.AddSingleton(conf);

        services.AddHttpClient("default", c =>
        {
            c.BaseAddress = new Uri(conf["TFS:Url"]);
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", "7g64qsgfnq2ansmqlpt6cwzk4hut4hpwbnw3mf7ldhcw3v7h5tja"))));
        });

        services.AddDbContext<DevOpsDbContext>(option => option.UseSqlServer(conf["TFS:DB"]));
        
        return services.BuildServiceProvider();
    }


    private static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
    }
}
