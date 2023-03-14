using KVNO.TFS.Server.Data;
using KVNO.TFS.Shared.Models;
using System.Globalization;

namespace KVNO.TFS.Server.DL
{
    public class ProjectLogic
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _conf;
        private readonly ILogger<ProjectLogic> _logger;
        public ProjectLogic(IHttpClientFactory clientFactory, IConfiguration conf, ILogger<ProjectLogic> logger)
        {
            _http = clientFactory.CreateClient("default");
            _conf = conf;
            _logger = logger;
        }

        public async Task<DevOpsProject[]?> GetProjectsAsync(string collectionName, string collectionId)
        {
            var tfsProjects = await _http.GetFromJsonAsync<TFSModels.Project.Rootobject>($"{collectionName}/_apis/projects");
            if (tfsProjects is not null)
            {
                List<DevOpsProject> projects = new();
                foreach (var p in tfsProjects.value)
                {
                    projects.Add(await ProjectTransform(p, collectionId));
                }
                return projects.ToArray();
            }
            return null;
        }

        private async Task CreateOrUpdate()
        {

        }

        private async Task<DevOpsProject> ProjectTransform(TFSModels.Project.Value value, string collectionId)
        {
            var p = new DevOpsProject();

            p.Id = value.id;
            p.Name = value.name;
            p.Url = value.url;
            p.State = value.state;
            if (!string.IsNullOrEmpty(value.description))
                p.Description = value.description;
            p.LastUpdateTime = value.lastUpdateTime;
            p.Revision = value.revision;
            p.Visibility = value.visibility;
            p.CollectionId = collectionId;

            return p;
        }
    }
}
