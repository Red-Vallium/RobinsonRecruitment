using Microsoft.AspNetCore.Mvc;
using Robinson.Models;
using Robinson.Services;


namespace Robinson.Controllers
{
    [ApiController]
    public class PathFindingController : ControllerBase
    {
        private readonly PathService _pathService;

        public PathFindingController(PathService pathService)
        {
            _pathService = pathService;
        }

        [HttpGet("/{request}")]
        public ActionResult<PathFindingResponseModel> Index([FromRoute]string request)
        {
            var output = _pathService.GetPath(request.ToUpper());
            return Ok(output);
        }
    }
}
