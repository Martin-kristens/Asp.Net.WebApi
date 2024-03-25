using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos;

public class CourseRegistrationForm
{
    [Required]
    public string Title { get; set; } = null!;
    public string? Author { get; set; }
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public bool BestSeller { get; set; } = false;
    public string? LikesInProcent { get; set; }
    public string? LikesInNumbers { get; set; }
}
