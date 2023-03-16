using KVNO.TFS.Client.Services;
using KVNO.TFS.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace KVNO.TFS.Client.Components
{
    public partial class WorkItemComponent
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public WorkItemService Ws { get; set; }

        public DevOpsWorkItem WorkItem { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            WorkItem = await Ws.GetById(Id);
        }

    }
}
