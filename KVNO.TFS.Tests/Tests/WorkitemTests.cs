using KVNO.TFS.Server.Data;
using KVNO.TFS.Server.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KVNO.TFS.Server.Tests;

public class WorkitemTests
{
    private readonly DevOpsDbContext _context;
    private readonly IWorkItemLogic _logic;
    public WorkitemTests()
    {
        var sp = new DI().Start().Result;

        _context = sp.GetRequiredService<DevOpsDbContext>();
        _logic = sp.GetRequiredService<IWorkItemLogic>();
    }

    [Fact]
    public async Task Get_Workitems_From_AzureDevOps()
    {
        string collectionName = "it";
        string projectName = "Telematik Infrastruktur";
        string projectId = "a72877ab-8388-4e5c-8910-13fa8441fadc";
        string workItem = "Task";
        var workitems = await _logic.GetWorkitemsAsync(collectionName, projectName, projectId, workItem);
        Assert.NotNull(workitems);
    }

    [Fact]
    public void Get_Workitems_From_Database()
    {
        var workitems = _context.WorkItems.ToList();
        Assert.InRange(workitems.Count, 1, int.MaxValue);
     }

    [Theory]
    [InlineData("a72877ab-8388-4e5c-8910-13fa8441fadc-16168")]
    [InlineData("a72877ab-8388-4e5c-8910-13fa8441fadc-16208")]
    [InlineData("a72877ab-8388-4e5c-8910-13fa8441fadc-17454")]
    [InlineData("a72877ab-8388-4e5c-8910-13fa8441fadc-17943")]
    [InlineData("a72877ab-8388-4e5c-8910-13fa8441fadc-2144")]
    public async Task Get_Workitem_From_AzureDevOps_By_ID(string workItemID)
    {
        string collectionName = "it";
        string projectName = "Telematik Infrastruktur";
        string projectId = "a72877ab-8388-4e5c-8910-13fa8441fadc";
        string workItem = "Task";
        var workitems = await _logic.GetWorkitemsAsync(collectionName, projectName, projectId, workItem);

        var workitem = workitems.FirstOrDefault(x => x.Id.Equals(workItemID));
        Assert.NotNull(workitem);
    }

    [Theory]
    [InlineData("BE: Logik Mock")]
    [InlineData("FE: Logik")]
    [InlineData("FE: Implementierung")]
    [InlineData("FE: abgeschlossene und anstehende Quartale anzeigen")]
    [InlineData("Report anpassen")]
    public void Get_WorkItem_From_Database_By_Name(string name)
    {
        var workitem = _context.WorkItems.FirstOrDefault(x => x.Title.Equals(name));
        Assert.NotNull(workitem);
    }

    [Theory]
    [InlineData("a72877ab-8388-4e5c-8910-13fa8441fadc-16173")]
    [InlineData("a72877ab-8388-4e5c-8910-13fa8441fadc-16185")]
    [InlineData("a72877ab-8388-4e5c-8910-13fa8441fadc-16226")]
    [InlineData("a72877ab-8388-4e5c-8910-13fa8441fadc-18468")]
    [InlineData("a72877ab-8388-4e5c-8910-13fa8441fadc-25414")]
    public void Get_WorkItem_From_Database_And_Checking_For_Completed_Times_Lower_As_Estimated_Time(string workItemId)
    {
        var workitem = _context.WorkItems.FirstOrDefault(x => x.Id.Equals(workItemId));

        if (workitem.EstimateTime < workitem.CompletedTime)
            Assert.Fail("Completed Time was Greater as Estimated Time");
    }
}
