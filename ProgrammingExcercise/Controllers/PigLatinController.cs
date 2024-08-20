using Microsoft.AspNetCore.Mvc;
using ProgrammingExercise.Services;

namespace ProgrammingExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PigLatinController : ControllerBase
    {
        public PigLatinController()
        {
        }

        [HttpGet(Name = "piggy")]
        public async Task<IActionResult> Get()
        {
            var currentTime = await TimeProviderHelper.GetCurrentTime();

            return await Task.FromResult(new OkObjectResult(currentTime));
        }
    }
}
