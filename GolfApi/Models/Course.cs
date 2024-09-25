namespace GolfApi.Models
{
    // Model class for representing a golf course
    public class Course
    {
        // ID of the course
        public int CourseID { get; set; }

        // Name of the course
        public string? CourseName { get; set; }

        // Par score of the course
        public int Par { get; set; }

        // Strokes score of the course (nullable)
        public int? Strokes { get; set; }

        // Navigation property: collection of rounds associated with this course
        public ICollection<Round>? Rounds { get; set; }
    }
}
