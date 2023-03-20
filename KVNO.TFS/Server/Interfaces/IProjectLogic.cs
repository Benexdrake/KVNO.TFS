namespace KVNO.TFS.Server.Interfaces;

public interface IProjectLogic
{
    Task<DevOpsProject[]?> GetProjectsAsync(string collectionName, string collectionId);
}