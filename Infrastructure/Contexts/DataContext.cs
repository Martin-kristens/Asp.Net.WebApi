using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<SubscriberEntity> Subscribers { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
}
