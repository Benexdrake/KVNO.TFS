namespace KVNO.TFS.Client.Services;

public class ProjectService : IProjectService
{
    private readonly HttpClient _http;
    public ProjectService(HttpClient http)
    {
        _http = http;
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
