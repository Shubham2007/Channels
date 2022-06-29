using ChannelDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChannelDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("GetA")]
        public async Task<IActionResult> GetA([FromServices] ITest testService)
        {
            await testService.BackgroudTask();
            return Ok("Given task completed");
        }

        [HttpGet("GetB")]
        public async Task<IActionResult> GetB([FromServices] ITest testService)
        {
            await testService.BackgroudTaskB();
            return Ok("Given task completed");
        }
    }
}
