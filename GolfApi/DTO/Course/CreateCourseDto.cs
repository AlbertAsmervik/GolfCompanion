namespace GolfApi.DTO.Course
{
    // DTO (Data Transfer Object) for creating a course
    public class CreateCourseDto
    {
        // Name of the course
        public string CourseName { get; set; }

        // Par value of the course
        public int Par { get; set; }

        // Optional property for strokes of the course
        public int? Strokes { get; set; }
    }
}
