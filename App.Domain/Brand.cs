using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class Brand : BaseEntity
{
    [MaxLength(256)]
    public string BrandName { get; set; } = default!;
    
    [MaxLength(256)]
    public string HeadquartersLocation { get; set; } = default!;
    
    [MaxLength(256)]
    public string ContactEmail { get; set; } = default!;
    
    [MaxLength(256)]
    public string ContactPhone { get; set; } = default!;
    
    public ICollection<Paint>? Paints { get; set; }
    public ICollection<PaintLine>? PaintLines { get; set; }
}