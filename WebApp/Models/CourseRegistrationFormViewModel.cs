using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class CourseRegistrationFormViewModel
{
    [Required]
    [Display(Name = "Title")]
    public string Title { get; set; } = null!;

    [Display(Name = "Author(s)")]
    public string? Author { get; set; }

    [Display(Name = "Price")]
    public string? Price { get; set; }

    [Display(Name = "Discount price")]
    public string? DiscountPrice { get; set; }

    [Display(Name = "Hours")]
    public string? Hours { get; set; }

    [Display(Name = "Best Seller")]
    public bool BestSeller { get; set; } = false;

    [Display(Name = "Likes in procent")]
    public string? LikesInProcent { get; set; }

    [Display(Name = "Likes in numbers")]
    public string? LikesInNumbers { get; set; }
}
