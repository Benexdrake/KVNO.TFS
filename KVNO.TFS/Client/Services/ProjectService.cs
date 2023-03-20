using KVNO.TFS.Shared.Models;
using System.Net.Http.Json;

namespace KVNO.TFS.Client.Services
{
    public class ProjectService
    {
        private readonly HttpClient _http;
        public ProjectService(IServiceProvider service)
        {
            _http = service.GetRequiredService<HttpClient>();
        }

        public async Task<DevOpsProject[]?> GetProjects(string collectionName, string collectionId)
        {
            var projects = await _http.GetFromJsonAsync<DevOpsProject[]>($"api/project?collectionName={collectionName}&collectionId={collectionId}");
            return projects;
        }

        public async Task<DevOpsProject?> GetProject(string projectId)
        {
            var projects = await _http.GetFromJsonAsync<DevOpsProject>($"api/project/id?projectId={projectId}");
            return projects;
        }

        public async Task<DevOpsProject[]?> GetProjectByName(string projectName)
        {
            var projects = await _http.GetFromJsonAsync<DevOpsProject[]>($"api/project/name?name={projectName}");
            return projects;
        }
    }
}
