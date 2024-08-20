using Microsoft.AspNetCore.Mvc;
using ProgrammingExercise.Features.AlgoLand.v1.Services;

namespace ProgrammingExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlgoController : ControllerBase
    {
        private readonly IAlgoRunnerService _algoRunnerService;

        public AlgoController(IAlgoRunnerService algoRunnerService)
        {
            _algoRunnerService = algoRunnerService;
        }

        [HttpGet]
        [Route("v1")]
        public async Task<IActionResult> Get()
        {
            var result = await _algoRunnerService.GetResult();

            if (!result.IsValid)
            {
                return await Task.FromResult(new BadRequestObjectResult(result.Error));
            }

            return await Task.FromResult(new OkObjectResult(result.Data));
        }
    }
}
