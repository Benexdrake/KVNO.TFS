namespace KVNO.TFS.Server.Interfaces;

public interface IProjectLogic
{
    Task GetProjectsAsync(string collectionName, string collectionId);
}