
using CMNHousing.PropertyService.Data;
using CMNHousing.PropertyService.DTOs;
using CMNHousing.PropertyService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace CMNHousing.PropertyService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly AppDbContext _context;

    public PropertyController(AppDbContext context)
    {
        _context = context;
    }

    // =========================
    // GET: api/Property
    // Get All Properties
    // =========================
    [HttpGet]
    public async Task<IActionResult> GetAllProperties()
    {
        var properties = await _context.Properties
            .Select(x => new PropertyDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                PropertyType = x.PropertyType,
                Price = x.Price,
                Location = x.Location,
                Bedrooms = x.Bedrooms,
                Bathrooms = x.Bathrooms,
                Area = x.Area,
                OwnerId = x.OwnerId,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync();

        return Ok(properties);
    }

    // =========================
    // GET: api/Property/1
    // Get Property By Id
    // =========================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPropertyById(int id)
    {
        var property = await _context.Properties
            .Where(x => x.Id == id)
            .Select(x => new PropertyDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                PropertyType = x.PropertyType,
                Price = x.Price,
                Location = x.Location,
                Bedrooms = x.Bedrooms,
                Bathrooms = x.Bathrooms,
                Area = x.Area,
                OwnerId = x.OwnerId,
                CreatedAt = x.CreatedAt
            })
            .FirstOrDefaultAsync();

        if (property == null)
        {
            return NotFound("Property not found.");
        }

        return Ok(property);
    }

    // =========================
    // POST: api/Property
    // Create Property
    // =========================
    [HttpPost]
    public async Task<IActionResult> CreateProperty(PropertyDto dto)
    {
        var property = new Property
        {
            Title = dto.Title,
            Description = dto.Description,
            PropertyType = dto.PropertyType,
            Price = dto.Price,
            Location = dto.Location,
            Bedrooms = dto.Bedrooms,
            Bathrooms = dto.Bathrooms,
            Area = dto.Area,
            OwnerId = dto.OwnerId,
            CreatedAt = DateTime.UtcNow
        };

        _context.Properties.Add(property);
        await _context.SaveChangesAsync();

        dto.Id = property.Id;
        dto.CreatedAt = property.CreatedAt;

        return Ok(dto);
    }

    // =========================
    // PUT: api/Property/1
    // Update Property
    // =========================
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProperty(
        int id,
        PropertyDto dto)
    {
        var property = await _context.Properties
            .FirstOrDefaultAsync(x => x.Id == id);

        if (property == null)
        {
            return NotFound("Property not found.");
        }

        property.Title = dto.Title;
        property.Description = dto.Description;
        property.PropertyType = dto.PropertyType;
        property.Price = dto.Price;
        property.Location = dto.Location;
        property.Bedrooms = dto.Bedrooms;
        property.Bathrooms = dto.Bathrooms;
        property.Area = dto.Area;
        property.OwnerId = dto.OwnerId;

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Property updated successfully"
        });
    }

    // =========================
    // DELETE: api/Property/1
    // Delete Property
    // =========================
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProperty(int id)
    {
        var property = await _context.Properties
            .FirstOrDefaultAsync(x => x.Id == id);

        if (property == null)
        {
            return NotFound("Property not found.");
        }

        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Property deleted successfully"
        });
    }
}
