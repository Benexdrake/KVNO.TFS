namespace KVNO.TFS.Client.Components.Collection
{
    public partial class CollectionComponent
    {
        [Inject]
        public NavigationManager NM { get; set; }
        [Parameter]
        public ProjectWithDetails[] ProjectsWithDetails { get; set; }

        private void Open(string projectId)
        {
            Console.WriteLine(projectId);
            NM.NavigateTo($"project/{projectId}");
        }
        string Check(float estimate, float complete)
        {
            if (complete > estimate)
                return "bad.png";
            return "ok.png";
        }
    }
}