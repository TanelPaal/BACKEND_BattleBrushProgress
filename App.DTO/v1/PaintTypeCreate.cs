using System.ComponentModel.DataAnnotations;

namespace App.DTO.v1;

public class PaintTypeCreate
{
    [MaxLength(64)]
    public string Name { get; set; } = default!; // Acrylic, enamel, wash etc
    
    [MaxLength(256)]
    public string Description { get; set; } = default!;
}