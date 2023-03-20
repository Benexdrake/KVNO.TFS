namespace KVNO.TFS.Server.Interfaces;

public interface IWorkItemLogic
{
    Task<DevOpsWorkItem[]?> GetWorkitemsAsync(string collectionName, string projectName, string projectId, string workItem);
}