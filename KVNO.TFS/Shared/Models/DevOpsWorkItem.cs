namespace KVNO.TFS.Shared.Models;
public class DevOpsWorkItem
{
    public DevOpsWorkItem(string id, string title, string assignetUser, string state, string type, string reason, DateTime created, DateTime lastChange, DateTime activated, float remainingTime, float estimateTime, float completedTime, string projectId)
    {
        Id = id;
        Title = title;
        AssignetUser = assignetUser;
        State = state;
        Type = type;
        Reason = reason;
        Created = created;
        LastChange = lastChange;
        Activated = activated;
        RemainingTime = remainingTime;
        EstimateTime = estimateTime;
        CompletedTime = completedTime;
        ProjectId = projectId;
    }
    public DevOpsWorkItem()
    {

    }

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
    public string ProjectId { get; set; }
}
