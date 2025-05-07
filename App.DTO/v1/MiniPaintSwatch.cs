using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class MiniPaintSwatch : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public string UsageType { get; set; } = default!;
    
    public string Notes { get; set; } = default!;
    
    // Relationships
    public Guid MiniatureCollectionId { get; set; }
    
    public Guid PersonPaintsId { get; set; }

}