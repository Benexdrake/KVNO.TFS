namespace KVNO.TFS.Client.Interfaces;

public interface IProjectService
{
    Task<DevOpsProject?> GetProject(string projectId);
    Task<DevOpsProject[]?> GetProjectByName(string projectName);
    Task<DevOpsProject[]?> GetProjects(string collectionName, string collectionId);
}