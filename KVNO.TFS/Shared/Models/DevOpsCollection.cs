namespace KVNO.TFS.Shared.Models;

public class DevOpsCollection
{
    public DevOpsCollection(string id, string name)
    {
        Id = id;
        Name = name;
    }
    public DevOpsCollection()
    {

    }

    public string Id { get; set; }
    public string Name { get; set; }
}
