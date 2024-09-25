namespace GolfApi.Controllers;

// Importing necessary libraries
using GolfApi.DTO.Course;
using Microsoft.AspNetCore.Mvc;
using GolfApi.Data;
using GolfApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// ApiController attribute specifies that the class responds to HTTP API requests
// Route attribute specifies the route for accessing the controller
[ApiController]
[Route("[controller]")]
public class CoursesController : ControllerBase
{
    private readonly GolfAppContext _context;

    // Constructor to initialize the controller with a GolfAppContext instance
    public CoursesController(GolfAppContext context)
    {
        _context = context;
    }
    
    // GET: api/courses
    // Retrieves all courses from the database
    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _context.Courses.ToListAsync();
        return Ok(courses);
    }

    // GET: api/courses/{id}
    // Retrieves a specific course by its ID from the database
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }

    // POST: api/courses
    // Creates a new course in the database
    [HttpPost]
    public async Task<IActionResult> PostCourse(CreateCourseDto createCourseDto)
    {
        var course = new Course
        {
            CourseName = createCourseDto.CourseName,
            Par = createCourseDto.Par,
            Strokes = createCourseDto.Strokes
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCourse), new { id = course.CourseID }, course);
    }

    // PUT: api/courses/{id}
    // Updates an existing course in the database
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCourse(int id, UpdateCourseDto updateCourseDto)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }

        course.CourseName = updateCourseDto.CourseName;
        course.Par = updateCourseDto.Par;
        course.Strokes = updateCourseDto.Strokes;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/courses/{id}
    // Deletes a course from the database
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // GET: api/courses/best-course
    // Retrieves the course with the smallest amount of strokes from the database
    [HttpGet("best-course")]
    public async Task<IActionResult> GetBestCourse()
    {
        var bestCourse = await _context.Courses
            .OrderBy(c => c.Strokes)
            .Select(c => new { c.CourseName, c.Strokes, c.Par })
            .FirstOrDefaultAsync();
        
        if (bestCourse == null)
        {
            return NotFound("No courses found.");
        }

        return Ok(bestCourse);
    }
}


