namespace KVNO.TFS.Shared.Models;
public class DevOpsWorkItem
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string ProjectTitle { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public string AssignetUser { get; set; } = string.Empty;
    public string AssignetUserAvatar { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime LastChange { get; set; }
    public DateTime Activated { get; set; }
    public int Priority { get; set; }
    public float RemainingTime { get; set; }
    public float EstimateTime { get; set; }
    public float CompletedTime { get; set; }
    public string ProjectId { get; set; } = string.Empty;

}
