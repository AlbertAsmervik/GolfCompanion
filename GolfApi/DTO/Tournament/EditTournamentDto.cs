namespace GolfApi.DTO.Tournament
{
    // DTO (Data Transfer Object) for editing a tournament
    public class EditTournamentDto
    {
        // ID of the tournament to be edited
        public int TournamentID { get; set; }

        // Updated name of the tournament
        public string TournamentName { get; set; }

        // Updated start date of the tournament
        public DateTime StartDate { get; set; }

        // Updated end date of the tournament
        public DateTime EndDate { get; set; }

        // Updated location of the tournament
        public string Location { get; set; }

        // Updated ID of the course where the tournament will be held
        public int CourseID { get; set; }
    }
}

