﻿using System.ComponentModel;

namespace Infrastructure.Entities;

public class CourseEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Author { get; set; }
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public bool BestSeller { get; set; }
    public string? LikesInProcent { get; set; }
    public string? LikesInNumbers { get; set; }

    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public string? ImageUrl { get; set; }
    public string? BigImageUrl { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}
