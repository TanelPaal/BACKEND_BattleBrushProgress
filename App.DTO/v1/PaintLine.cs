using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class PaintLine : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(128)]
    public string PaintLineName { get; set; } = default!;
    
    [MaxLength(256)]
    public string Description { get; set; } = default!;
    
    // Add Relationship
    public Guid BrandId { get; set; }
}