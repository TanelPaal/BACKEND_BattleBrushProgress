using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniPaintSwatch : BaseEntity
{
    [MaxLength(50)]
    public string UsageType { get; set; } = default!;
    
    public string Notes { get; set; } = default!;
    
    // Relationships
    public Guid MiniatureCollectionId { get; set; }
    public MiniatureCollection? MiniatureCollection { get; set; }
    
    public Guid UserPaintsId { get; set; }
    public UserPaints? UserPaints { get; set; }
}