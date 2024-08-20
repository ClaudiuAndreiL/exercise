using Microsoft.AspNetCore.Mvc;

namespace TimeProviderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeProviderController : ControllerBase
    {
        public TimeProviderController()
        {
        }

        [HttpGet(Name = "current-time")]
        public async Task<IActionResult> Get()
        {
            var datetime = DateTime.UtcNow;

            return await Task.FromResult(new OkObjectResult(datetime));
        }
    }
}
