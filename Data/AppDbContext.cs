
using CMNHousing.PropertyService.Models;
using Microsoft.EntityFrameworkCore;

namespace CMNHousing.PropertyService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Property> Properties { get; set; }
}
