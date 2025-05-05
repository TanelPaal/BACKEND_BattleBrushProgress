using System.ComponentModel.DataAnnotations;

namespace App.DAL.DTO;

public class PaintType
{
    [MaxLength(64)]
    [Display(Name = nameof(Name), Prompt = nameof(Name), ResourceType = typeof(App.Resources.Domain.PaintType))]
    public string Name { get; set; } = default!; // Acrylic, enamel, wash etc
    
    [MaxLength(256)]
    [Display(Name = nameof(Description), Prompt = nameof(Description), ResourceType = typeof(App.Resources.Domain.PaintType))]
    public string Description { get; set; } = default!;
    
    public ICollection<Paint>? Paints { get; set; }
}