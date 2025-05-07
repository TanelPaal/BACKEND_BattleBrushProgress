using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class Paint : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(128)]
    public string Name { get; set; } = default!;
    
    [MaxLength(7)]
    public string HexCode { get; set; } = default!;
    
    [MaxLength(12)]
    public string UPC { get; set; } = default!; // Universal Product Code
    
    // Add relationships
    public Guid BrandId { get; set; }
    
    public Guid PaintTypeId { get; set; }
    
    public Guid? PaintLineId { get; set; }
    
}