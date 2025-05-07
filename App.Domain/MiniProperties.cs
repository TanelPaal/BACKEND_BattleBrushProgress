using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniProperties : BaseEntity
{
    [MaxLength(64, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(PropertyName), Prompt = nameof(PropertyName), ResourceType = typeof(App.Resources.Domain.MiniProperties))]
    public string PropertyName { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(PropertyDesc), Prompt = nameof(PropertyDesc), ResourceType = typeof(App.Resources.Domain.MiniProperties))]
    public string PropertyDesc { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(Miniatures), Prompt = nameof(Miniatures), ResourceType = typeof(App.Resources.Domain.MiniProperties))]
    public ICollection<Miniature>? Miniatures { get; set; }
}