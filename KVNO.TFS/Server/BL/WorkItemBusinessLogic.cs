namespace KVNO.TFS.Server.BL;

public class WorkItemBusinessLogic
{
    public WorkItemsDetails WorkItemsDetailsConverter(DevOpsWorkItem[] workItems)
    {
        var details = new WorkItemsDetails();
        details.Count = workItems.Length;
        foreach (var workItem in workItems)
        {
            details.CompletedTime += workItem.CompletedTime;
            details.EstimatedTime += workItem.EstimateTime;
            details.RemainingTime += workItem.RemainingTime;
        }
        return details;
    }
}
