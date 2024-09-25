namespace GolfApi.Models
{
    // Model class for representing a golf tournament
    public class Tournament
    {
        // ID of the tournament
        public int TournamentID { get; set; }

        // Name of the tournament
        public string? TournamentName { get; set; }

        // Start date of the tournament
        public DateTime StartDate { get; set; }

        // End date of the tournament
        public DateTime EndDate { get; set; }

        // Location of the tournament
        public string? Location { get; set; }

        // ID of the course where the tournament is held
        public int? CourseID { get; set; }

        // Navigation property: course where the tournament is held
        public Course Course { get; set; }
    }
}

    