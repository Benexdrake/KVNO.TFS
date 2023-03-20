using KVNO.TFS.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace KVNO.TFS.Client.Tests.Tests;

public class ProjectTests
{
    private readonly CollectionService _cs;
    private readonly ProjectService _ps;
    public ProjectTests()
    {
        var sp = new DI().Start().Result;
        _cs = sp.GetRequiredService<CollectionService>();
        _ps = sp.GetRequiredService<ProjectService>();
    }

    // Get all projects and check for count
    [Fact]
    public async Task Get_Projects_From_Service()
    {
        var collection = await _cs.GetCollectionById("054a1095-4850-489d-b0f4-52ad100c9006");
        if (collection is null)
            Assert.Fail("Collection was Null");
        var projects = await _ps.GetProjects(collection.Name,collection.Id);
        Assert.InRange(projects.Length, 1, int.MaxValue);
    }

    // Get a Project by Name -multi 5
    [Theory]
    [InlineData("RLV2")]
    [InlineData("IT-Betrieb")]
    [InlineData("Abrechnung1")]
    [InlineData("Portal Registrierung")]
    [InlineData("Telematik Infrastruktur")]

    public async Task Get_A_Single_Project_By_Name(string projectName)
    {
        var projects = await _ps.GetProjectByName(projectName);
        if (projects is null)
            Assert.Fail("Project was null");
        if (projects.Length < 1)
            Assert.Fail("Found not enough Projects, exspected 1");
    }

    // Get a Project by Id -multi 5
}
