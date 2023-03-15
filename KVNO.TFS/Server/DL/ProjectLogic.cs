namespace KVNO.TFS.Server.DL;

public class ProjectLogic : IProjectLogic
{
    private readonly HttpClient _http;
    private readonly IConfiguration _conf;
    private readonly ILogger<ProjectLogic> _logger;
    private readonly DevOpsDbContext _context;

    public ProjectLogic(IHttpClientFactory clientFactory, IConfiguration conf, ILogger<ProjectLogic> logger, DevOpsDbContext context)
    {
        _http = clientFactory.CreateClient("default");
        _conf = conf;
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Get all Projects from a specific Collection, finding them by collection Name
    /// </summary>
    /// <param name="collectionName"></param>
    /// <param name="collectionId"></param>
    /// <returns></returns>
    public async Task GetProjectsAsync(string collectionName, string collectionId)
    {
        try
        {
            var tfsProjects = await _http.GetFromJsonAsync<TFSModels.Project.Rootobject>($"{collectionName}/_apis/projects");
            if (tfsProjects is not null)
            {
                foreach (var p in tfsProjects.value)
                {
                    var project = await ProjectTransform(p, collectionId);
                    await CreateOrUpdate(project);
                }
            }
        }
        catch (Exception err)
        {
            _logger.LogError(err.Message, err);
        }
    }

    private async Task<DevOpsProject> ProjectTransform(TFSModels.Project.Value value, string collectionId)
    {
        var p = new DevOpsProject();

        p.Id = value.id;
        p.Name = value.name;
        if (!string.IsNullOrEmpty(value.description))
            p.Description = value.description;
        p.LastUpdateTime = value.lastUpdateTime;
        p.CollectionId = collectionId;
        return p;
    }

    private async Task CreateOrUpdate(DevOpsProject p)
    {
        try
        {

            var pDb = _context.Projects.FirstOrDefault(x => x.Id.Equals(p.Id));
            if (pDb is null)
            {
                _context.Projects.Add(p);
                await _context.SaveChangesAsync();
            }
            else
            {
                pDb.Description = p.Description;
                pDb.LastUpdateTime = p.LastUpdateTime;
                pDb.Name = p.Name;
                pDb.CollectionId = p.CollectionId;
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception err)
        {
            _logger.LogError(err.Message, err);
        }
    }
}
