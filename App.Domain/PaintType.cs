using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class PaintType : BaseEntity
{
    [MaxLength(64, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(Name), Prompt = nameof(Name), ResourceType = typeof(App.Resources.Domain.PaintType))]
    public string Name { get; set; } = default!; // Acrylic, enamel, wash etc
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(Description), Prompt = nameof(Description), ResourceType = typeof(App.Resources.Domain.PaintType))]
    public string Description { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(Paints), Prompt = nameof(Paints), ResourceType = typeof(App.Resources.Domain.PaintType))]
    public ICollection<Paint>? Paints { get; set; }
}