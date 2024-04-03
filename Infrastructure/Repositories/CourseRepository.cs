using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class CourseRepository(DataContext context) : ICourseRepository
{
    private readonly DataContext _context = context;

    public async Task<bool> CourseExists(int id)
    {
        try
        {
            return await _context.Courses.AnyAsync(c => c.Id == id);
        }
        catch (Exception ex) { Debug.WriteLine("Something went wrong" + ex.Message); }
        return false;
    }

    public async Task<bool> CourseExists(string title)
    {
        try
        {
            return await _context.Courses.AnyAsync(c => c.Title == title);
        }
        catch (Exception ex) { Debug.WriteLine("Something went wrong" + ex.Message); }
        return false;
    }

    public async Task<bool> CreateCourse(CourseEntity course)
    {
        try
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) { Debug.WriteLine("Something went wrong" + ex.Message); }
        return false;
    }

    public async Task<ICollection<CourseEntity>> GetAll()
    {
        try
        {
            return await _context.Courses.OrderBy(c => c.Id).ToListAsync();
        }
        catch (Exception ex) { Debug.WriteLine("Somethin went wrong while fetching all courses" + ex.Message); }
        return null!;
    }

    public async Task<CourseEntity> GetById(int id)
    {
        try
        {
            return await _context.Courses.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception ex) { Debug.WriteLine("Somethin went wrong while fetching a course by Id" + ex.Message); }
        return null!;
    }
}
