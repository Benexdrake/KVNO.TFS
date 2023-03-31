namespace KVNO.TFS.Client.Pages;

public partial class CollectionPage
{
    [Inject]
    public ICollectionService cs { get; set; }
    [Inject]
    public IProjectService ps { get; set; }
    [Inject]
    public IWorkItemService ws { get; set; }


    [Parameter]
    public string Id { get; set; } = string.Empty;
    public string CollectionName { get; set; }
    public ProjectWithDetails[] ProjectWithDetails { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await ShowProjects();
    }

    public async Task ShowProjects()
    {
        var collection = await cs.GetCollections();
        if (collection is not null)
        {
            List<ProjectWithDetails> projectWithDetails = new List<ProjectWithDetails>();
            CollectionName = collection.FirstOrDefault(x => x.Id.Equals(Id)).Name;
            var projects = await ps.GetProjects(CollectionName, Id);
            foreach (var p in projects)
            {
                var w = await ws.GetWorkItemDetails(p.Id);
                if (w is not null)
                    projectWithDetails.Add(new(p, w));
            }
            ProjectWithDetails = projectWithDetails.ToArray();
        }
    }
}
