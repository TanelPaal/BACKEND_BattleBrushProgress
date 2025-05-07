using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class Miniature : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(256)]
    public string MiniName { get; set; } = default!;
    
    public string MiniDesc { get; set; } = default!;
    
    // Relationships
    public Guid MiniFactionId { get; set; }
    
    public Guid MiniPropertiesId { get; set; }
    
    public Guid MiniManufacturerId { get; set; }
    
}