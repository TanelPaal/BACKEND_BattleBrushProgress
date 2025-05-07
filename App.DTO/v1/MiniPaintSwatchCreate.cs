using System.ComponentModel.DataAnnotations;

namespace App.DTO.v1;

public class MiniPaintSwatchCreate
{
    [MaxLength(50)]
    public string UsageType { get; set; } = default!;
    
    public string Notes { get; set; } = default!;
    
    // Relationships
    public Guid MiniatureCollectionId { get; set; }
    
    public Guid PersonPaintsId { get; set; }
}