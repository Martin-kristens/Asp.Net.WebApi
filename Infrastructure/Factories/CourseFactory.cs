using Infrastructure.Dtos;
using Infrastructure.Entities;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class CourseFactory
{
    public static CourseDto Create(CourseEntity entity)
    {
		try
		{
			return new CourseDto
			{
				Id = entity.Id,
				Title = entity.Title,
				Author = entity.Author,
				Price = entity.Price,	
				DiscountPrice = entity.DiscountPrice,
				Hours = entity.Hours,
				BestSeller = entity.BestSeller,
				LikesInProcent = entity.LikesInProcent,
				LikesInNumbers = entity.LikesInNumbers,
				ImageUrl = entity.ImageUrl,
				BigImageUrl = entity.BigImageUrl,
				Category = entity.Category!.CategoryName
			};
		}
		catch (Exception ex)
		{

			Debug.WriteLine(ex.Message);
		}
		return null!;
    }

    public static IEnumerable<CourseDto> Create(List<CourseEntity> entities)
    {
        List<CourseDto> courses = [];
        try
        {
            foreach (var entity in entities)
            {
                courses.Add(Create(entity));
            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex.Message);
        }
        return courses;
    }
}
