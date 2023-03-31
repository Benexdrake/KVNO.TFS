namespace KVNO.TFS.Client.Interfaces;

public interface IWorkItemService
{
    Task<DevOpsWorkItem?> GetById(string id);
    Task<DevOpsWorkItem[]?> GetByProjectId(string projectId);
    Task<DevOpsWorkItem[]?> GetWorkItems(string collectionName, string projectName, string projectId, string workItem);
    Task<WorkItemsDetails?> GetWorkItemDetails(string projectId);
    Task<DevOpsWorkItem[]?> GetWorkItemsByState(string state);
}