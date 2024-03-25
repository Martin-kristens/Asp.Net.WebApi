using Infrastructure.Entities;

namespace WebApi.Models;

public class CourseModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Author { get; set; }
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public bool BestSeller { get; set; } = false;
    public string? LikesInProcent { get; set; }
    public string? LikesInNumbers { get; set; }

    public static implicit operator CourseModel(CourseEntity courseEntity)
    {
        return new CourseModel
        {
            Id = courseEntity.Id,
            Title = courseEntity.Title,
            Author = courseEntity.Author,
            Price = courseEntity.Price,
            DiscountPrice = courseEntity.DiscountPrice,
            Hours = courseEntity.Hours,
            BestSeller = courseEntity.BestSeller,
            LikesInProcent = courseEntity.LikesInProcent,
            LikesInNumbers = courseEntity.LikesInNumbers,
        };
    }
}
