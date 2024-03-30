using Infrastructure.Entities;

namespace Infrastructure.Interfaces;

public interface ICourseRepository
{
    Task<ICollection<CourseEntity>> GetAll();
    Task<CourseEntity> GetById(int id);
    Task<bool> CourseExists(int id);
    Task<bool> CourseExists(string title);
    Task<bool> CreateCourse(CourseEntity courseEntity);
}
