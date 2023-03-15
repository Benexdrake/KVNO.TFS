using KVNO.TFS.Client;
using KVNO.TFS.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CollectionService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<WorkItemService>();

await builder.Build().RunAsync();
