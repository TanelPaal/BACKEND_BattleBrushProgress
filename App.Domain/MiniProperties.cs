using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniProperties : BaseEntity
{
    [MaxLength(64)]
    [Display(Name = nameof(PropertyName), Prompt = nameof(PropertyName), ResourceType = typeof(App.Resources.Domain.MiniProperties))]
    public string PropertyName { get; set; } = default!;
    
    [Display(Name = nameof(PropertyDesc), Prompt = nameof(PropertyDesc), ResourceType = typeof(App.Resources.Domain.MiniProperties))]
    public string PropertyDesc { get; set; } = default!;
    
    public ICollection<Miniature>? Miniatures { get; set; }
}