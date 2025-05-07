using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class PaintType : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(64)]
    public string Name { get; set; } = default!; // Acrylic, enamel, wash etc
    
    [MaxLength(256)]
    public string Description { get; set; } = default!;
}