using KVNO.TFS.Client.Services;
using KVNO.TFS.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace KVNO.TFS.Client.Components;

public partial class CollectionComponent
{
    [Inject]
    public CollectionService cs { get; set; }
    [Inject]
    public ProjectService ps { get; set; }
    [Inject]
    public WorkItemService ws { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }


    [Parameter]
    public string Id { get; set; } = string.Empty;

    public string CollectionName { get; set; }
    public string Time { get; set; }

    public DevOpsProject[] Projects { get; set; } = null;
    public int[] WorkItems { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        Stopwatch sw = new();
        sw.Start();
        var collection = await cs.GetCollections();
        if (collection is not null)
        {
            string collectionName = collection.FirstOrDefault(x => x.Id.Equals(Id))?.Name;
            CollectionName = collectionName;
            var projects = await ps.GetProjects(collectionName, Id);
            if (projects is not null)
            {
                List<int> WorkItemList = new();
                foreach (var project in projects)
                {
                    var workitems = await ws.GetAllByProjectId(project.Id);
                    WorkItemList.Add(workitems);
                }
                WorkItems = WorkItemList.ToArray();
                Projects = projects;
            }
        }
        Time = sw.Elapsed.ToString();
        sw.Stop();
    }

    public void OpenProject(string projectId)
    {
        NavigationManager.NavigateTo($"project/{projectId}");
    }
}
