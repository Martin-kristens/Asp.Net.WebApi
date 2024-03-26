using Infrastructure.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(ICourseRepository courseRepository, ICourseService courseService) : ControllerBase
{
    private readonly ICourseRepository _courseRepository = courseRepository;
    private readonly ICourseService _courseService = courseService;

    #region GET
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CourseRegistrationForm>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var courses = await _courseRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(courses);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(CourseRegistrationForm))]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            if (!await _courseRepository.CourseExists(id))
                return NotFound();

            var course = await _courseRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(course);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return NoContent();
    }
    #endregion

    #region CREATE
    [HttpPost]
    public async Task<IActionResult> CreateOne(CourseRegistrationForm form)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courseExists = await _courseRepository.CourseExists(form.Title);
            if (courseExists)
                return Conflict("A course with the same Title already exists");

            var course = await _courseService.CreateCourse(form);
            if (course)
                return Created("", course);
            else
                return StatusCode(500, "Failed to create the course");

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return NoContent();
    }
    #endregion
}
