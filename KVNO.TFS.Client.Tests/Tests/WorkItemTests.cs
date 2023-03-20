using KVNO.TFS.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace KVNO.TFS.Client.Tests;

public class WorkItemTests
{
    private readonly CollectionService _cs;
    private readonly ProjectService _ps;
    private readonly WorkItemService _ws;
    public WorkItemTests()
    {
        var sp = new DI().Start().Result;

        _cs = sp.GetRequiredService<CollectionService>();  
        _ps = sp.GetRequiredService<ProjectService>();
        _ws = sp.GetRequiredService<WorkItemService>();
    }

    [Fact]
    public async Task GetWorkitems()
    {
        var collections = await _cs.GetCollections();
        var collection1 = collections.FirstOrDefault();
        var projects = await _ps.GetProjects(collection1.Name, collection1.Id);
        var project1 = projects.FirstOrDefault();
        var workitems = await _ws.GetWorkItems(collection1.Name, project1.Name, project1.Id, "Task");

        Assert.InRange(workitems.Length, 1, int.MaxValue);
    }
}
