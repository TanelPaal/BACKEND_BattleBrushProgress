using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class PaintLine : BaseEntity
{
    [MaxLength(128)]
    public string PaintLineName { get; set; }
    
    [MaxLength(256)]
    public string Description { get; set; } = default!;
    
    // Add Relationship
    public Guid BrandId { get; set; }
    public Brand? Brand { get; set; }
    
}