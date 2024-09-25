namespace GolfApi.DTO.Tournament
{
    // DTO (Data Transfer Object) for adding a tournament
    public class AddTournamentDto
    {
        // Name of the tournament
        public string TournamentName { get; set; }

        // Start date of the tournament
        public DateTime StartDate { get; set; }

        // End date of the tournament
        public DateTime EndDate { get; set; }

        // Location of the tournament
        public string Location { get; set; }

        // ID of the course where the tournament will be held
        public int CourseID { get; set; }
    }
}
