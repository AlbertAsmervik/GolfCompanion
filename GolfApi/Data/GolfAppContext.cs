using Microsoft.EntityFrameworkCore;
using GolfApi.Models;

namespace GolfApi.Data
{
    // Represents the database context for the GolfApp
    public class GolfAppContext : DbContext
    {
        // Constructor for the GolfAppContext, accepting DbContextOptions
        public GolfAppContext(DbContextOptions<GolfAppContext> options) : base(options)
        {
        }

        // DbSet for the Player entity
        public DbSet<Player>? Players { get; set; }

        // DbSet for the Course entity
        public DbSet<Course>? Courses { get; set; }

        // DbSet for the Round entity
        public DbSet<Round>? Rounds { get; set; }

        // DbSet for the Tournament entity
        public DbSet<Tournament>? Tournaments { get; set; }
    }
}
