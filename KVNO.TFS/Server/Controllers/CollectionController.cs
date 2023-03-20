namespace KVNO.TFS.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CollectionController : ControllerBase
{
    private readonly ICollectionLogic _logic;
    private readonly DevOpsDbContext _context;
    public CollectionController(ICollectionLogic logic, DevOpsDbContext context)
    {
        _logic = logic;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetCollections()
    {
        await _logic.GetCollectionsAsync();
        var collections = _context.Collections.ToList();
        if (collections is not null)
            return Ok(collections);
        return BadRequest();
    }

    [HttpGet("id")]
    public async Task<ActionResult> GetCollection(string collectionId)
    {
        var collection = _context.Collections.FirstOrDefault(c => c.Id.Equals(collectionId));
        if (collection is not null)
            return Ok(collection);
        return BadRequest();
    }
}
