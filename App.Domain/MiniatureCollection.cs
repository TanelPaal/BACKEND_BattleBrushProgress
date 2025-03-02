using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniatureCollection : BaseEntity
{
    [MaxLength(256)]
    public string CollectionName { get; set; } = default!;
    
    public string CollectionDesc { get; set; } = default!;
    
    public DateTime AcquisitionDate { get; set; }
    
    public DateTime? CompletionDate { get; set; }
    
    // Relationships
    public Guid MiniatureId { get; set; }
    public Miniature? Miniature { get; set; }
    
    public Guid MiniStateId { get; set; }
    public MiniState? MiniState { get; set; }
    
    public ICollection<MiniPaintSwatch>? MiniPaintSwatches { get; set; }
}