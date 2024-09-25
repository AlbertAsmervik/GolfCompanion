namespace GolfApi.DTO.Tournament
{
    // DTO (Data Transfer Object) for a tournament with associated course information
    public class TournamentWithCourseDto
    {
        // ID of the tournament
        public int TournamentID { get; set; }

        // Name of the tournament
        public string TournamentName { get; set; }

        // Start date of the tournament
        public DateTime StartDate { get; set; }

        // End date of the tournament
        public DateTime EndDate { get; set; }

        // Location of the tournament
        public string Location { get; set; }

        // Course information associated with the tournament
        public CourseDTO Course { get; set; }
    }

    // DTO for course information
    public class CourseDTO
    {
        // ID of the course
        public int CourseID { get; set; }

        // Name of the course
        public string CourseName { get; set; }
    }
}
