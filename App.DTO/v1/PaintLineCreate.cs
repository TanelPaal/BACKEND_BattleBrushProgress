using System.ComponentModel.DataAnnotations;

namespace App.DTO.v1;

public class PaintLineCreate
{
    [MaxLength(128)]
    public string PaintLineName { get; set; } = default!;
    
    [MaxLength(256)]
    public string Description { get; set; } = default!;
    
    // Add Relationship
    public Guid BrandId { get; set; }
}