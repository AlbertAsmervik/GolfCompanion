using Microsoft.AspNetCore.Mvc;
using GolfApi.Services; // Importing GolfApiService from Services namespace

//under development, ID key seems to be wrong will look further into in next step of development
namespace GolfApi.Controllers
{
    [ApiController] // Specifies that the class responds to HTTP API requests
    [Route("[controller]")] // Specifies the route for accessing the controller
    public class GolfStatsController : ControllerBase
    {
        private readonly GolfApiService _golfApiService;

        // Constructor to initialize the controller with a GolfApiService instance
        public GolfStatsController(GolfApiService golfApiService)
        {
            _golfApiService = golfApiService;
        }

        // GET: api/golfstats
        // Retrieves golf statistics using the GolfApiService asynchronously
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stats = await _golfApiService.GetGolfStatsAsync();
            return Ok(stats);
        }
    }
}
