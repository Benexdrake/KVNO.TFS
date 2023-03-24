namespace KVNO.TFS.Client.Pages;

public partial class WorkItemPage
{
    [Parameter]
    public string Id { get; set; }

    [Inject]
    public IWorkItemService Ws { get; set; }

    public DevOpsWorkItem WorkItem { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        WorkItem = await Ws.GetById(Id);
    }

}
