using Infrastructure.Dtos;

namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Task<bool> CreateCourse(CourseRegistrationForm form);
    Task<bool> Save();
}
