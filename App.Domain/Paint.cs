using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class Paint : BaseEntity
{
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    [MaxLength(7)]
    public string HexCode { get; set; } = default!;
    
    [MaxLength(12)]
    public string UPC { get; set; } = default!; // Universal Product Code
    
    // Add relationships
    public Guid BrandId { get; set; }
    public Brand? Brand { get; set; }
    
    public Guid PaintTypeId { get; set; }
    public PaintType? PaintType { get; set; }
    
    // Navigation property for UserPaints
    public ICollection<UserPaints>? UserPaints { get; set; }
}