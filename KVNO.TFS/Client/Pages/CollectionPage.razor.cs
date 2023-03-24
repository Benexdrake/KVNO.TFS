namespace KVNO.TFS.Client.Pages;

public partial class CollectionPage
{
    [Inject]
    public ICollectionService cs { get; set; }
    [Inject]
    public IProjectService ps { get; set; }
    [Inject]
    public IWorkItemService ws { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }


    [Parameter]
    public string Id { get; set; } = string.Empty;
    public string CollectionName { get; set; }
    public DevOpsProject[] Projects { get; set; } = null;
    public WorkItemsDetails[] WorkItemsDetails { get; set; }

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
                List<WorkItemsDetails> details = new();
                foreach (var project in projects)
                {
                    var detail = await ws.GetWorkItemDetails(project.Id);
                    details.Add(detail);
                }
                WorkItemsDetails = details.ToArray();
                Projects = projects;
            }
        }
    }

    public void OpenProject(string projectId)
    {
        NavigationManager.NavigateTo($"project/{projectId}");
    }
}
