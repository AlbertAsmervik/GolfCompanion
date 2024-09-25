namespace GolfApi.DTO.Course
{
    // DTO (Data Transfer Object) for updating a course
    public class UpdateCourseDto
    {
        // Updated name of the course
        public string CourseName { get; set; }

        // Updated par value of the course
        public int Par { get; set; }

        // Optional property for updated strokes of the course
        public int? Strokes { get; set; }
    }
}
