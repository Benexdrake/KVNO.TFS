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
    public DevOpsProject[] Projects { get; set; } = null;
    public int[] WorkItems { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await ShowProjects();
    }

    public async Task ShowProjects()
    {
        var collection = await cs.GetCollections();
        if (collection is not null)
        {
            CollectionName = collection.FirstOrDefault(x => x.Id.Equals(Id)).Name;
            var projects = await ps.GetProjects(CollectionName, Id);
            if (projects is not null)
            {
                List<int> WorkItemList = new();
                foreach (var project in projects)
                {
                    var workitems = await ws.GetWorkItemsCountByProjectId(project.Id);
                    WorkItemList.Add(workitems);
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
