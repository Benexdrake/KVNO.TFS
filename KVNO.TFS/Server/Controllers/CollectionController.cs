using KVNO.TFS.Server.DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KVNO.TFS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly CollectionLogic _logic;
        public CollectionController(IServiceProvider service)
        {
            _logic = service.GetRequiredService<CollectionLogic>();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var collections = await _logic.GetCollectionsAsync();
            if (collections is not null)
                return Ok(collections);
            return BadRequest();
        }
    }
}
