using KVNO.TFS.Server.Data;
using KVNO.TFS.Server.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KVNO.TFS.Server.Tests;

public class ProjectTests
{
    private readonly DevOpsDbContext _context;
    private readonly IProjectLogic _logic;
    public ProjectTests()
    {
        var sp = new DI().Start().Result;
        _logic = sp.GetRequiredService<IProjectLogic>();
        _context = sp.GetRequiredService<DevOpsDbContext>();
    }

    [Fact]
    public async Task Get_Projects_From_AzureDevOps()
    {
        var test = await _logic.GetProjectsAsync("Pilot", "a235c705-421e-4268-8f49-48765288468d");
        Assert.NotNull(test);
    }

    [Fact]
    public async Task Get_Projects_From_Database()
    {
        var projects = _context.Projects.ToList();
        Assert.InRange(projects.Count, 1, int.MaxValue);
    }

    [Theory]
    [InlineData("it","054a1095-4850-489d-b0f4-52ad100c9006")] // IT
    [InlineData("KV_extern","3d305a43-835a-48b1-8f3a-ddffcfef3bee")] // KV Extern
    [InlineData("Pilot","a235c705-421e-4268-8f49-48765288468d")] // Pilot
    public async Task Get_Projects_With_CollectionID_From_AzureDevOps(string collectionName,string collectionId)
    {
        var projects = await _logic.GetProjectsAsync(collectionName,collectionId);
        Assert.NotNull(projects);
    }

    [Theory]
    [InlineData("054a1095-4850-489d-b0f4-52ad100c9006")] // IT
    [InlineData("3d305a43-835a-48b1-8f3a-ddffcfef3bee")] // KV Extern
    [InlineData("a235c705-421e-4268-8f49-48765288468d")] // Pilot
    public async Task Get_Projects_With_CollectionID_From_Database(string collectionId)
    {
        var projects = _context.Projects.Where(x => x.CollectionId.Equals(collectionId));
        Assert.NotNull(projects);
    }

    [Theory]
    [InlineData("IT-Betrieb")]
    [InlineData("Zervix-Zytologie")]
    [InlineData("Arztregister")]
    [InlineData("Komponenten")]
    [InlineData("Telematik Infrastruktur")]
    public void Get_A_Single_Project_By_Project_Name(string projectName)
    {
        var project = _context.Projects.FirstOrDefault(x => x.Name.Equals(projectName));
        Assert.NotNull(project);
    }

    [Theory]
    [InlineData("2022-10-18 12:21:39.6200000")]
    [InlineData("2023-03-14 17:36:02.0030000")]
    [InlineData("2020-10-05 13:25:21.3330000")]
    [InlineData("2017-03-31 13:43:45.5900000")]
    [InlineData("2023-02-24 08:40:03.1900000")]
    public void Get_A_Single_Project_By_Last_Update(DateTime lastUpdate)
    {
        var project = _context.Projects.FirstOrDefault(x => x.LastUpdateTime == lastUpdate);
        Assert.NotNull(project);
    }
}
