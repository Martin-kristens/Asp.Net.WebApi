using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Courses.ToListAsync());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);   
            if (course != null)
            {
                return Ok(course);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOne(CourseRegistrationForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var courseEntity = new CourseEntity
                    {
                        Title = form.Title,
                        Author = form.Author,
                        Price = form.Price,
                        DiscountPrice = form.DiscountPrice,
                        Hours = form.Hours,
                        BestSeller = form.BestSeller,
                        LikesInProcent = form.LikesInProcent,
                        LikesInNumbers = form.LikesInNumbers,
                    };

                    _context.Courses.Add(courseEntity);
                    await _context.SaveChangesAsync();

                    return Created("", (CourseModel)courseEntity);
                }

                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}
