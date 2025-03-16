using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniPaintSwatch : BaseEntity
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
    
    [Display(Name = nameof(UserPaints), Prompt = nameof(UserPaints), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public Guid UserPaintsId { get; set; }
    [Display(Name = nameof(UserPaints), Prompt = nameof(UserPaints), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public UserPaints? UserPaints { get; set; }
}