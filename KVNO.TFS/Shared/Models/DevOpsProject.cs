namespace KVNO.TFS.Shared.Models;

public class DevOpsProject
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public int Revision { get; set; }
    public string Visibility { get; set; } = string.Empty;
    public DateTime LastUpdateTime { get; set; }
    public string CollectionId { get; set; } = string.Empty;
    public DevOpsWorkItem[] WorkItems { get; set; }
}
