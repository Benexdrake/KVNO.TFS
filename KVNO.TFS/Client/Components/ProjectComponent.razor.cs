using KVNO.TFS.Client.Services;
using KVNO.TFS.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace KVNO.TFS.Client.Components
{
    public partial class ProjectComponent
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public CollectionService Cs { get; set; }
        [Inject]
        public ProjectService Ps { get; set; }
        [Inject]
        public WorkItemService Ws { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public DevOpsProject? Project { get; set; }
        public DevOpsWorkItem[]? WorkItems { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Project = await Ps.GetProject(Id);
            var collection = await Cs.GetCollectionById(Project.CollectionId);
            WorkItems = await Ws.GetWorkItems(collection.Name, Project.Name, Project.Id, "Task");

        }

        public void OpenWorkItem(string workitemId)
        {
            NavigationManager.NavigateTo($"workitem/{workitemId}");
        }
    }
}
