namespace KVNO.TFS.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectLogic _logic;
    private readonly DevOpsDbContext _context;
    public ProjectController(IProjectLogic logic, DevOpsDbContext context)
    {
        _logic = logic;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetProjects(string collectionName, string collectionId)
    {
        await _logic.GetProjectsAsync(collectionName, collectionId);
        var projects = _context.Projects.Where(x => x.CollectionId.Equals(collectionId)).ToList();
        if(projects is not null)
            return Ok(projects);
        return BadRequest();
    }

    [HttpGet("id")]
    public async Task<ActionResult> GetProjectById(string projectId)
    {
        var project = _context.Projects.FirstOrDefault(x => x.Id.Equals(projectId));
        if(project is not null) 
            return Ok(project);
        return BadRequest();
    }

    [HttpGet("name")]
    public async Task<ActionResult> GetProjectsByName(string name)
    {
        var projects = _context.Projects.Where(x => x.Name.Contains(name)).ToList();
        if(projects is not null)
            return Ok(projects);
        return BadRequest();
    }

    [HttpGet("searchsuggestion")]
    public async Task<ActionResult> GetSearchSuggestion(string searchtext, string collectionId)
    {
        var collection = _context.Collections.FirstOrDefault(x => x.Id.Equals(collectionId));
        var suggestion = _logic.GetProjectSearchSuggestion(searchtext, collectionId,collection.Name);

        if(suggestion is not null) 
            return Ok(suggestion);
        return BadRequest();
    }

    [HttpGet("all")]
    public async Task<ActionResult> GetAll()
    {
        var projects = _context.Projects.ToList();
        if (projects is not null)
            return Ok(projects);
        return BadRequest();
    }
}
