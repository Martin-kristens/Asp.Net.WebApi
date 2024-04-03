using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<bool> CreateCourse(CourseRegistrationForm form)
    {
        try
        {
            bool courseAlreadyExists = await _courseRepository.CourseExists(form.Title);

            if (courseAlreadyExists)
            {
                return courseAlreadyExists;
            }

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

            await _courseRepository.CreateCourse(courseEntity);

            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public Task<bool> Save()
    {
        throw new NotImplementedException();
    }
}
