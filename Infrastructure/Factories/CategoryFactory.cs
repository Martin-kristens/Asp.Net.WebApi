using Infrastructure.Dtos;
using Infrastructure.Entities;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class CategoryFactory
{
    public static CategoryDto Create(CategoryEntity entity)
    {
		try
		{
			return new CategoryDto
			{
				Id = entity.Id,
				CategoryName = entity.CategoryName,
			};
		}
		catch (Exception ex)
		{

			Debug.WriteLine(ex.Message);
		}
		return null!;
    }

    public static IEnumerable<CategoryDto> Create(List<CategoryEntity> entities)
    {
        List<CategoryDto> categories = [];
        try
        {
           foreach (var entity in entities)
            {
                categories.Add(Create(entity));
            }
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex.Message);
        }
        return categories;
    }
}
