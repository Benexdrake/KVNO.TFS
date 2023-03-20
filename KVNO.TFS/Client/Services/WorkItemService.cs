using KVNO.TFS.Shared.Models;
using System.Collections;
using System.Net.Http.Json;

namespace KVNO.TFS.Client.Services
{
    public class WorkItemService
    {
        private readonly HttpClient _http;
        public WorkItemService(IServiceProvider service)
        {
            _http = service.GetRequiredService<HttpClient>();
        }

        public async Task<DevOpsWorkItem[]?> GetWorkItems(string collectionName, string projectName, string projectId, string workItem)
        {
            var workItems = await _http.GetFromJsonAsync<DevOpsWorkItem[]>($"api/workitem?collectionName={collectionName}&projectName={projectName}&projectId={projectId}&workItem={workItem}");
            return workItems;
        }

        public async Task<DevOpsWorkItem[]?> GetByProjectId(string projectId)
        {
            var workItems = await _http.GetFromJsonAsync<DevOpsWorkItem[]>($"api/workitem/projectid?projectid={projectId}");
            return workItems;
        }

        public async Task<DevOpsWorkItem?> GetById(string id)
        {
            var workItem = await _http.GetFromJsonAsync<DevOpsWorkItem>($"api/workitem/id?id={id}");
            return workItem;
        }

        public async Task<int> GetAllByProjectId(string projectId)
        {
            var workItems = await _http.GetFromJsonAsync<int>($"api/workitem/all?projectId={projectId}");
            return workItems;
        }
        
    }
}
