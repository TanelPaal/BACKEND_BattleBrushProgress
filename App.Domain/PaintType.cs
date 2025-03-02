using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class PaintType : BaseEntity
{
    [MaxLength(64)]
    public string Name { get; set; } = default!; // Acrylic, enamel, wash etc
    
    [MaxLength(256)]
    public string Description { get; set; } = default!;
    
    public ICollection<Paint>? Paints { get; set; }
}