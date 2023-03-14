using KVNO.TFS.Server.Data;
using KVNO.TFS.Server.TFSModels.WorkItemsID;
using KVNO.TFS.Shared.Models;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Xml.Linq;

namespace KVNO.TFS.Server.DL
{
    public class WorkItemLogic
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _conf;
        private readonly ILogger<CollectionLogic> _logger;
        private readonly DevOpsDbContext _context;

        public WorkItemLogic(IHttpClientFactory clientFactory, IConfiguration conf, ILogger<CollectionLogic> logger)
        {
            _http = clientFactory.CreateClient("default");
            _conf = conf;
            _logger = logger;
        }

        public async Task<DevOpsWorkItem[]?> GetWorkitemsAsync(string collectionName, string projectName ,string projectId, string workItem)
        {
            var url = $"{collectionName}/{projectId}";
            var ids = await GetWorkItemIDs(projectName, workItem, url + "/_apis/wit/wiql?api-version=5.1");
            if(ids is not null)
            {
                foreach (var id in ids)
                {
                    var task = await GetWorkItemAsync(url + $"/_apis/wit/workItems/{id}", projectId);
                }
            }
            return null;
        }

        public async Task<DevOpsWorkItem?> GetWorkItemAsync(string url, string projectId)
        {
            var response = await _http.GetFromJsonAsync<TFSModels.WorkItem.Rootobject>(url);
            if(response is not null)
            {
                return await WorkitemTransform(response, projectId);
            }
            return null;
        }

        private async Task<int[]?> GetWorkItemIDs(string projectName, string workItem, string url)
        {
            string query = $"Select [System.Id], [System.Title], [System.State] From WorkItems " +
                                                                                           $"Where [System.WorkItemType] = '{workItem}' AND [System.TeamProject] = '{projectName}' order by [Microsoft.VSTS.Common.Priority] " +
                                                                                           $"asc, [System.CreatedDate] desc";

            var response = await _http.PostAsJsonAsync(url, new { query });
            if(response.IsSuccessStatusCode)
            {
                List<int> ids = new List<int>();
                string responseBody = await response.Content.ReadAsStringAsync();
                responseBody = responseBody
                .Replace("System.", "System")
                .Replace("Microsoft.VSTS.Common.", "MicrosoftVSTSCommon")
                .Replace("Microsoft.VSTS.Scheduling.", "MicrosoftVSTSScheduling");
                var ts = JsonConvert.DeserializeObject<TFSModels.WorkItemsID.Rootobject>(responseBody);
                foreach(var id in ts.workItems) 
                {
                    ids.Add(id.id);
                }
                return ids.ToArray();
            }
            return null;
        }

        private async Task<DevOpsWorkItem?> WorkitemTransform(TFSModels.WorkItem.Rootobject root, string projectId)
        {
            DevOpsWorkItem? at = new();
            at.Id = $"{projectId}-{root.id}";
            if (!string.IsNullOrEmpty(root.fields.SystemTitle))
                at.Title = root.fields.SystemTitle;
            at.Url = root.url;
            if (!string.IsNullOrEmpty(root.fields.SystemTeamProject))
                at.ProjectTitle = root.fields.SystemTeamProject;
            if (!string.IsNullOrEmpty(root.fields.SystemWorkItemType))
                at.Type = root.fields.SystemWorkItemType;
            if (!string.IsNullOrEmpty(root.fields.SystemState))
                at.State = root.fields.SystemState;
            if (!string.IsNullOrEmpty(root.fields.SystemReason))
                at.Reason = root.fields.SystemReason;
            if (!string.IsNullOrEmpty(root.fields.SystemAssignedTo?.displayName))
                at.AssignetUser = root.fields.SystemAssignedTo?.displayName;
            if (!string.IsNullOrEmpty(root.fields.SystemAssignedTo?.imageUrl))
                at.AssignetUserAvatar = root.fields.SystemAssignedTo?.imageUrl;
            if (!string.IsNullOrEmpty(root.fields.SystemCreatedDate))
                at.Created = DateTime.Parse(root.fields.SystemCreatedDate);
            if (!string.IsNullOrEmpty(root.fields.SystemChangedDate))
                at.LastChange = DateTime.Parse(root.fields.SystemChangedDate);
            if (!string.IsNullOrEmpty(root.fields.MicrosoftVSTSCommonActivatedDate))
                at.Activated = DateTime.Parse(root.fields.MicrosoftVSTSCommonActivatedDate);
            at.Priority = root.fields.MicrosoftVSTSCommonPriority;
            at.RemainingTime = root.fields.MicrosoftVSTSSchedulingRemainingWork;
            at.EstimateTime = root.fields.MicrosoftVSTSSchedulingOriginalEstimate;
            at.CompletedTime = root.fields.MicrosoftVSTSSchedulingCompletedWork;

            return at;
        }
    }
}
