namespace KVNO.TFS.Server.Interfaces;

public interface ICollectionLogic
{
    Task CreateOrUpdate(DevOpsCollection c);
    Task GetCollectionsAsync();
}