using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Factories;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(ICourseRepository courseRepository, ICourseService courseService, DataContext context) : ControllerBase
{
    private readonly ICourseRepository _courseRepository = courseRepository;
    private readonly ICourseService _courseService = courseService;
    private readonly DataContext _context = context;

    #region GET
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CourseDto>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAll(string category = "", string searchQuery = "")
    {
        var query = _context.Courses.Include(i => i.Category).AsQueryable();
        //dropdownsökning
        if (!string.IsNullOrWhiteSpace(category) && category != "all")
        {
            query = query.Where(x => x.Category.CategoryName == category);
        }

        //fritextsökning
        if (!string.IsNullOrEmpty(searchQuery))
        {
            query = query.Where(x => x.Title.Contains(searchQuery) || x.Author!.Contains(searchQuery));
        }


        query = query.OrderByDescending(o => o.LastUpdated);

        var courses = await query.ToListAsync();

        var response = new CourseResultDto
        {
            Succeeded = true,
            Courses = CourseFactory.Create(courses)
        };

        return Ok(response);

        //try
        //{
        //    var courses = await _courseRepository.GetAll();

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    return Ok(courses);
        //}
        //catch (Exception ex) { Debug.WriteLine(ex.Message); }
        //return NoContent();
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
