using Microsoft.EntityFrameworkCore;

namespace GolfApi.Controllers
{
    using GolfApi.DTO.Player;
    using Microsoft.AspNetCore.Mvc;
    using GolfApi.Data;
    using GolfApi.Models;
    using System.Threading.Tasks;

    [ApiController] // Specifies that the class responds to HTTP API requests
    [Route("[controller]")] // Specifies the route for accessing the controller
    public class PlayersController : ControllerBase
    {
        private readonly GolfAppContext _context;

        // Constructor to initialize the controller with a GolfAppContext instance
        public PlayersController(GolfAppContext context)
        {
            _context = context;
        }

        // GET: api/players
        // Retrieves all players asynchronously
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return Ok(players);
        }

        // GET: api/players/{id}
        // Retrieves a player by ID asynchronously
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        // POST: api/players
        // Adds a new player asynchronously
        [HttpPost]
        public async Task<IActionResult> PostPlayer(CreatePlayerDto createPlayerDto)
        {
            var player = new Player
            {
                FirstName = createPlayerDto.FirstName,
                LastName = createPlayerDto.LastName,
                Handicap = createPlayerDto.Handicap
            };

            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerID }, player);
        }

        // PUT: api/players/{id}
        // Updates a player by ID asynchronously
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, UpdatePlayerDto updatePlayerDto)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            player.FirstName = updatePlayerDto.FirstName;
            player.LastName = updatePlayerDto.LastName;
            player.Handicap = updatePlayerDto.Handicap;

            await _context.SaveChangesAsync();
            return NoContent();
        }

            [HttpGet("hcp")]
        public async Task<IActionResult> GetHandicapForPlayer4()
        {
            var player = await _context.Players.FindAsync(4);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player.Handicap);
        }

        // DELETE: api/players/{id}
        // Deletes a player by ID asynchronously
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Checks if a player exists by ID could use this for better reusability
        private bool PlayerExists(int id) =>
            _context.Players.Any(e => e.PlayerID == id);
    }
}

