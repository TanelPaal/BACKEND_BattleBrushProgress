using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniManufacturer : BaseEntity
{
    [MaxLength(256)]
    public string ManufacturerName { get; set; } = default!;
    
    [MaxLength(256)]
    public string HeadquartersLocation { get; set; } = default!;
    
    [MaxLength(256)]
    public string ContactEmail { get; set; } = default!;
    
    [MaxLength(256)]
    public string ContactPhone { get; set; } = default!;
    
    public ICollection<Miniature>? Miniatures { get; set; }
}