using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfApi.Data;
using GolfApi.Models;
using Microsoft.AspNetCore.Http;
using GolfApi.DTO.Tournament;

namespace GolfApi.Controllers
{
    // Controller for handling tournament-related endpoints
    [Route("[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly GolfAppContext _context;

        // Constructor for TournamentController, injecting GolfAppContext
        public TournamentController(GolfAppContext context)
        {
            _context = context;
        }

        // GET: api/Tournament
        // Retrieves all tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournaments()
        {
            return await _context.Tournaments.ToListAsync();
        }

        // GET: api/Tournament/5
        // Retrieves a specific tournament by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        // POST: api/Tournament
        // Adds a new tournament to the database
        [HttpPost]
        public async Task<ActionResult<Tournament>> PostTournament(AddTournamentDto addTournamentDto)
        {
            var tournament = new Tournament
            {
                TournamentName = addTournamentDto.TournamentName,
                StartDate = addTournamentDto.StartDate,
                EndDate = addTournamentDto.EndDate,
                Location = addTournamentDto.Location,
                CourseID = addTournamentDto.CourseID
            };

            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTournament), new { id = tournament.TournamentID }, tournament);
        }

        // PUT: api/Tournament/5
        // Updates an existing tournament
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, EditTournamentDto editTournamentDto)
        {
            if (id != editTournamentDto.TournamentID)
            {
                return BadRequest();
            }

            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            tournament.TournamentName = editTournamentDto.TournamentName;
            tournament.StartDate = editTournamentDto.StartDate;
            tournament.EndDate = editTournamentDto.EndDate;
            tournament.Location = editTournamentDto.Location;
            tournament.CourseID = editTournamentDto.CourseID;

            _context.Entry(tournament).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Tournament/5
        // Deletes a tournament by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Checks if a tournament exists by its ID
        private bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(e => e.TournamentID == id);
        }

        // GET: api/Tournaments/WithCourses
        // Retrieves all tournaments with associated courses
        [HttpGet("WithCourses")]
        public async Task<ActionResult<IEnumerable<TournamentWithCourseDto>>> GetTournamentsWithCourses()
        {
            var tournamentsWithCourses = await _context.Tournaments
                .Where(t => t.StartDate >= DateTime.Now) // Assuming you want upcoming tournaments
                .Include(t => t.Course)
                .Select(t => new TournamentWithCourseDto
                {
                    TournamentID = t.TournamentID,
                    TournamentName = t.TournamentName,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    Location = t.Location,
                    Course = t.Course != null ? new CourseDTO
                    {
                        CourseID = t.Course.CourseID,
                        CourseName = t.Course.CourseName
                        // Map other course properties as needed
                    } : null
                })
                .ToListAsync();

            if (tournamentsWithCourses == null || !tournamentsWithCourses.Any())
            {
                return NotFound("No upcoming tournaments found.");
            }

            return Ok(tournamentsWithCourses);
        }
    }
}

