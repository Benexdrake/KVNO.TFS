namespace KVNO.TFS.Server.DL;

public class WorkItemLogic : IWorkItemLogic
{
    private readonly HttpClient _http;
    private readonly IConfiguration _conf;
    private readonly ILogger<CollectionLogic> _logger;
    private readonly DevOpsDbContext _context;

    public WorkItemLogic(IHttpClientFactory clientFactory, IConfiguration conf, ILogger<CollectionLogic> logger, DevOpsDbContext context)
    {
        _http = clientFactory.CreateClient("default");
        _conf = conf;
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Get all Workitems, like Task or Bug
    /// </summary>
    /// <param name="collectionName"></param>
    /// <param name="projectName"></param>
    /// <param name="projectId"></param>
    /// <param name="workItem"></param>
    /// <returns></returns>
    public async Task GetWorkitemsAsync(string collectionName, string projectName, string projectId, string workItem)
    {
        try
        {
            var url = $"{collectionName}/{projectId}";
            var ids = await GetWorkItemIDs(projectName, workItem, url + "/_apis/wit/wiql?api-version=5.1");
            if (ids is not null)
            {
                foreach (var id in ids)
                {
                    var wDb = _context.WorkItems.FirstOrDefault(x => x.Id.Equals($"{projectId}-{id}"));
                    if(wDb is not null)
                        if (wDb.State.Equals("Closed") || wDb.LastChange.Year < DateTime.Now.Year)
                            continue;
                    var task = await GetWorkItemAsync(collectionName, projectId, id);
                    if (task is not null)
                    {
                        await CreateOrUpdate(task);
                    }
                }   
            }
        }
        catch (Exception err)
        {
            _logger.LogError(err.Message, err);
        }
    }

    private async Task<DevOpsWorkItem?> GetWorkItemAsync(string collectionName, string projectId, int id)
    {
        try
        {
            string url = $"{collectionName}/{projectId}/_apis/wit/workItems/{id}";
            var response = await _http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                result = result
                            .Replace("System.", "System")
                            .Replace("Microsoft.VSTS.Common.", "MicrosoftVSTSCommon")
                            .Replace("Microsoft.VSTS.Scheduling.", "MicrosoftVSTSScheduling");
                var root = JsonConvert.DeserializeObject<TFSModels.WorkItem.Rootobject>(result);

                return await WorkitemTransform(root, projectId);
            }
        }
        catch (Exception err)
        {
            _logger.LogError(err.Message, err);
        }
        return null;
    }

    private async Task<int[]?> GetWorkItemIDs(string projectName, string workItem, string url)
    {
        try
        {
            string query = $"Select * From WorkItems " +
                                   $"Where [System.WorkItemType] = 'Task' AND [System.TeamProject] = '{projectName}' order by [Microsoft.VSTS.Common.Priority] " +
                                   $"asc, [System.CreatedDate] desc";

            var response = await _http.PostAsJsonAsync(url, new { query });
            if (response.IsSuccessStatusCode)
            {
                List<int> ids = new List<int>();
                string responseBody = await response.Content.ReadAsStringAsync();
                var ts = JsonConvert.DeserializeObject<TFSModels.WorkItemsID.Rootobject>(responseBody);
                foreach (var id in ts.workItems)
                {
                    ids.Add(id.id);
                }
                return ids.ToArray();
            }
        }
        catch (Exception err)
        {
            _logger.LogError(err.Message, err);
        }
        return null;
    }

    private async Task<DevOpsWorkItem?> WorkitemTransform(TFSModels.WorkItem.Rootobject root, string projectId)
    {
        DevOpsWorkItem? workitem = new();
        workitem.Id = $"{projectId}-{root.id}";
        if (!string.IsNullOrEmpty(root.fields.SystemTitle))
            workitem.Title = root.fields.SystemTitle;
        if (!string.IsNullOrEmpty(root.fields.SystemAssignedTo?.displayName))
            workitem.AssignetUser = root.fields.SystemAssignedTo?.displayName;
        workitem.State = root.fields.SystemState;
        workitem.Reason = root.fields.SystemReason;
        workitem.Type = root.fields.SystemWorkItemType;
        if (!string.IsNullOrEmpty(root.fields.SystemCreatedDate))
            workitem.Created = DateTime.Parse(root.fields.SystemCreatedDate);
        if (!string.IsNullOrEmpty(root.fields.SystemChangedDate))
            workitem.LastChange = DateTime.Parse(root.fields.SystemChangedDate);
        if (!string.IsNullOrEmpty(root.fields.MicrosoftVSTSCommonActivatedDate))
            workitem.Activated = DateTime.Parse(root.fields.MicrosoftVSTSCommonActivatedDate);
        workitem.RemainingTime = root.fields.MicrosoftVSTSSchedulingRemainingWork;
        workitem.EstimateTime = root.fields.MicrosoftVSTSSchedulingOriginalEstimate;
        workitem.CompletedTime = root.fields.MicrosoftVSTSSchedulingCompletedWork;
        workitem.ProjectId = projectId;
        workitem.ProjectName = root.fields.SystemTeamProject;
        return workitem;
    }

    private async Task CreateOrUpdate(DevOpsWorkItem w)
    {
        try
        {
            var wDb = _context.WorkItems.FirstOrDefault(x => x.Id.Equals(w.Id));
            if (wDb is null)
            {
                _context.WorkItems.Add(w);
                await _context.SaveChangesAsync();
            }
            else
            {
                wDb.Created = w.Created;
                wDb.ProjectName = w.ProjectName;
                wDb.LastChange = w.LastChange;
                wDb.Activated = w.Activated;
                wDb.RemainingTime = w.RemainingTime;
                wDb.EstimateTime = w.EstimateTime;
                wDb.CompletedTime = w.CompletedTime;
                wDb.ProjectId = w.ProjectId;
                wDb.AssignetUser = w.AssignetUser;
                wDb.Title = w.Title;
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception err)
        {
            _logger.LogError(err.Message, err);
        }
    }
}
