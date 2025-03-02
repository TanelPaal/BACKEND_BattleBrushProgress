using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class Miniature : BaseEntity
{
    [MaxLength(256)]
    public string MiniName { get; set; } = default!;
    
    public string MiniDesc { get; set; } = default!;
    
    // Relationships
    public Guid MiniFactionId { get; set; }
    public MiniFaction? MiniFaction { get; set; }
    
    public Guid MiniPropertiesId { get; set; }
    public MiniProperties? MiniProperties { get; set; }
    
    public Guid MiniManufacturerId { get; set; }
    public MiniManufacturer? MiniManufacturer { get; set; }
    
    public ICollection<MiniatureCollection>? MiniatureCollections { get; set; }
}