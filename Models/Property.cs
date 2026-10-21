
namespace CMNHousing.PropertyService.Models;

public class Property
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string PropertyType { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Location { get; set; } = string.Empty;

    public int Bedrooms { get; set; }

    public int Bathrooms { get; set; }

    public double Area { get; set; }

    public int OwnerId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
