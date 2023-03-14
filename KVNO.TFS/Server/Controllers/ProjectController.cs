using KVNO.TFS.Server.DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KVNO.TFS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectLogic _logic;
        public ProjectController(IServiceProvider service)
        {
            _logic = service.GetRequiredService<ProjectLogic>();
        }

        [HttpGet]
        public async Task<ActionResult> GetProjects(string collectionName, string collectionId)
        {
            var projects = await _logic.GetProjectsAsync(collectionName, collectionId);
            if(projects is not null)
                return Ok(projects);
            return BadRequest();
        }
    }
}
