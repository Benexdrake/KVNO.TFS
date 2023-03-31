namespace KVNO.TFS.Shared.Models
{
    public class ProjectWithDetails
    {
        public ProjectWithDetails(DevOpsProject project, WorkItemsDetails workItemsDetails)
        {
            Project = project;
            WorkItemsDetails = workItemsDetails;
        }
        public DevOpsProject Project { get; set; }
        public WorkItemsDetails WorkItemsDetails { get; set; }
    }
}
