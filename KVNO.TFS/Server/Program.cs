using KVNO.TFS.Server.Controllers;
using KVNO.TFS.Server.DL;
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<CollectionLogic>();
builder.Services.AddScoped<ProjectLogic>();
builder.Services.AddScoped<WorkItemLogic>();
builder.Services.AddScoped<CollectionController>();
builder.Services.AddScoped<ProjectController>();
builder.Services.AddScoped<WorkItemController>();


builder.Services.AddHttpClient("default", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Url"]);
    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", builder.Configuration["TFS:Token"]))));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
