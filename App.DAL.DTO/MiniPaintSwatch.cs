using System.ComponentModel.DataAnnotations;

namespace App.DAL.DTO;

public class MiniPaintSwatch
{
    [MaxLength(50)]
    [Display(Name = nameof(UsageType), Prompt = nameof(UsageType), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public string UsageType { get; set; } = default!;
    
    [Display(Name = nameof(Notes), Prompt = nameof(Notes), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public string Notes { get; set; } = default!;
    
    // Relationships
    [Display(Name = nameof(MiniatureCollection), Prompt = nameof(MiniatureCollection), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public Guid MiniatureCollectionId { get; set; }
    [Display(Name = nameof(MiniatureCollection), Prompt = nameof(MiniatureCollection), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public MiniatureCollection? MiniatureCollection { get; set; }
    
    [Display(Name = nameof(PersonPaints), Prompt = nameof(PersonPaints), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public Guid PersonPaintsId { get; set; }
    [Display(Name = nameof(PersonPaints), Prompt = nameof(PersonPaints), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public PersonPaints? PersonPaints { get; set; }

}