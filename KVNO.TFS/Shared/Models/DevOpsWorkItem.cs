namespace KVNO.TFS.Shared.Models;
public class DevOpsWorkItem
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string AssignetUser { get; set; } = string.Empty;
    public string State { get; set; }
    public string Type { get; set; }
    public string Reason { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastChange { get; set; }
    public DateTime Activated { get; set; }
    public float RemainingTime { get; set; }
    public float EstimateTime { get; set; }
    public float CompletedTime { get; set; }
    public string ProjectName { get; set; }
    public string ProjectId { get; set; }
}
