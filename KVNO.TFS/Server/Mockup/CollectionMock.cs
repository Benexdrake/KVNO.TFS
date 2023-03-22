namespace KVNO.TFS.Server.Mockup;

public class CollectionMock
{
    public DevOpsCollection[] GetCollectionMockups()
    {
        List<DevOpsCollection> devOpsCollections = new();
        var col1 = new DevOpsCollection("b2d72ea7-1d85-405c-a8b0-c916de0a4df4", "IT");
        var col2 = new DevOpsCollection("f51d0f4b-56d2-40e5-8b17-fbca93cf3bb9", "Testing");
        var col3 = new DevOpsCollection("3e57a5b0-dd25-46a1-845b-9028b2aa96a6", "Pilot");
    
        devOpsCollections.Add(col1);
        devOpsCollections.Add(col2);
        devOpsCollections.Add(col3);
    
        return devOpsCollections.ToArray();
    }
}
