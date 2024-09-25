using Microsoft.AspNetCore.Mvc;
using GolfApi.Data;
using GolfApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GolfApi.Controllers
{
    [ApiController] // Indicates that this class responds to HTTP API requests
    [Route("[controller]")] // Specifies the route for accessing the controller
    public class RoundsController : ControllerBase
    {
        private readonly GolfAppContext _context; // Instance of GolfAppContext to interact with the database

        public RoundsController(GolfAppContext context)
        {
            _context = context; // Constructor to inject GolfAppContext dependency
        }

        // GET: api/rounds
        // Retrieves all rounds asynchronously
        [HttpGet]
        public async Task<IActionResult> GetRounds()
        {
            var rounds = await _context.Rounds.ToListAsync();
            return Ok(rounds);
        }

        // GET: api/rounds/{id}
        // Retrieves a round by ID asynchronously
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRound(int id)
        {
            var round = await _context.Rounds
                .Include(r => r.Player) // Includes related player data
                .Include(r => r.Course) // Includes related course data
                .FirstOrDefaultAsync(r => r.RoundID == id);

            if (round == null)
            {
                return NotFound();
            }
            return Ok(round);
        }

        // POST: api/rounds
        // Adds a new round asynchronously
        [HttpPost]
        public async Task<IActionResult> PostRound(Round round)
        {
            _context.Rounds.Add(round);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRound), new { id = round.RoundID }, round);
        }

        // PUT: api/rounds/{id}
        // Updates a round by ID asynchronously
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRound(int id, Round round)
        {
            if (id != round.RoundID)
            {
                return BadRequest();
            }

            _context.Entry(round).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/rounds/{id}
        // Deletes a round by ID asynchronously
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRound(int id)
        {
            var round = await _context.Rounds.FindAsync(id);
            if (round == null)
            {
                return NotFound();
            }

            _context.Rounds.Remove(round);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/rounds/player/4
        // Retrieves all rounds for a specific player (ID 4) asynchronously
        [HttpGet("player/4")]
        public async Task<IActionResult> GetRoundsForPlayer4()
        {
            var rounds = await _context.Rounds
                .Include(r => r.Player)
                .Include(r => r.Course)
                .Where(r => r.PlayerID == 4)
                .ToListAsync();

            return Ok(rounds);
        }

        // Checks if a round exists by ID
        private bool RoundExists(int id)
        {
            return _context.Rounds.Any(e => e.RoundID == id);
        }
    }
}
