namespace KVNO.TFS.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkItemController : ControllerBase
{
    private readonly IWorkItemLogic _logic;
    private readonly DevOpsDbContext _context;
    public WorkItemController(IServiceProvider service)
    {
        _logic = service.GetRequiredService<IWorkItemLogic>();
        _context = service.GetRequiredService<DevOpsDbContext>();
    }

    [HttpGet]
    public async Task<ActionResult> Get(string collectionName, string projectName, string projectId, string workItem)
    {
        await _logic.GetWorkitemsAsync(collectionName, projectName, projectId, workItem);
        var workitems = _context.WorkItems.Where(x => x.ProjectId.Equals(projectId));
        if(workitems is not null)
            return Ok(workitems);
        return BadRequest();
    }

    [HttpGet("id")]
    public async Task<ActionResult> GetById(string id)
    {
        var workitem = _context.WorkItems.FirstOrDefault(x => x.Id.Equals(id));
        if( workitem is not null ) 
            return Ok(workitem);
        return BadRequest();
    }

    [HttpGet("name")]
    public async Task<ActionResult> GetByName(string name)
    {
        var workItem = _context.WorkItems.Where(x => x.Title.Contains(name));
        if (workItem is not null)
            return Ok(workItem);
        return BadRequest();
    }

    [HttpGet("projectid")]
    public async Task<ActionResult> GetByProjectId(string projectId)
    {
        var workitem = _context.WorkItems.Where(x => x.ProjectId.Equals(projectId));
        if (workitem is not null)
            return Ok(workitem);
        return BadRequest();
    }

    [HttpGet("all")]
    public async Task<ActionResult> GetAllByProjectId(string projectId)
    {
        var workitems = _context.WorkItems.Where(x => x.ProjectId.Equals(projectId));   
        if (workitems is not null)
            return Ok(workitems.ToList().Count);
        return BadRequest();
    }
}
