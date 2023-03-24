using KVNO.TFS.Server.Mockup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<ICollectionLogic, CollectionLogic>();
builder.Services.AddScoped<IProjectLogic, ProjectLogic>();
builder.Services.AddScoped<IWorkItemLogic, WorkItemLogic>();

builder.Services.AddScoped<CollectionController>();
builder.Services.AddScoped<ProjectController>();
builder.Services.AddScoped<WorkItemController>();

// Mockups
builder.Services.AddSingleton<CollectionMock>();
builder.Services.AddSingleton<ProjectMock>();
builder.Services.AddSingleton<WorkItemMock>();

builder.Services.AddScoped<WorkItemBusinessLogic>();

builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient("default", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["TFS:Url"]);
    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", builder.Configuration["TFS:Token"]))));
});

builder.Services.AddDbContext<DevOpsDbContext>(option => option.UseSqlServer(builder.Configuration["TFS:DB"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "KVNO.TFS.Server"); });
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
