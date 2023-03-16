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
    public DevOpsWorkItem[] WorkItems { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        var collection = await cs.GetCollections();
        if (collection is not null)
        {
            string collectionName = collection.FirstOrDefault(x => x.Id.Equals(Id))?.Name;
            CollectionName = collectionName;
            var projects = await ps.GetProjects(collectionName, Id);
            if (projects is not null)
            {
                List<DevOpsWorkItem> WorkItemList = new();
                foreach (var project in projects)
                {
                    var workitems = await ws.GetWorkItems(collectionName, project.Name, project.Id, "Task");
                    if (workitems is not null)
                        WorkItemList.AddRange(workitems);
                }
                WorkItems = WorkItemList.ToArray();
                Projects = projects;
            }
        }
    }

    public void OpenProject(string projectId)
    {
        NavigationManager.NavigateTo($"project/{projectId}");
    }
}
