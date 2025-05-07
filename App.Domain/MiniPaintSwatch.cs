using System.ComponentModel.DataAnnotations;
using App.Domain.Identity;
using Base.Domain;

namespace App.Domain;

public class MiniPaintSwatch : BaseEntityUser<AppUser>
{
    [MaxLength(50, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(UsageType), Prompt = nameof(UsageType), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public string UsageType { get; set; } = default!;
    
    [Display(Name = nameof(Notes), Prompt = nameof(Notes), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public string Notes { get; set; } = default!;
    
    // Relationships
    [Display(Name = nameof(MiniatureCollection), Prompt = nameof(MiniatureCollection), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public Guid MiniatureCollectionId { get; set; }
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(MiniatureCollection), Prompt = nameof(MiniatureCollection), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public MiniatureCollection? MiniatureCollection { get; set; }
    
    [Display(Name = nameof(PersonPaints), Prompt = nameof(PersonPaints), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public Guid PersonPaintsId { get; set; }
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(PersonPaints), Prompt = nameof(PersonPaints), ResourceType = typeof(App.Resources.Domain.MiniPaintSwatch))]
    public PersonPaints? PersonPaints { get; set; }

}