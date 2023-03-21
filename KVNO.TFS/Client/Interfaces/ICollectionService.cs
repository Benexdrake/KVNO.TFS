namespace KVNO.TFS.Client.Interfaces;

public interface ICollectionService
{
    Task<DevOpsCollection?> GetCollectionById(string collectionId);
    Task<DevOpsCollection[]?> GetCollections();
}