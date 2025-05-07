using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniFaction : BaseEntity
{
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(FactionName), Prompt = nameof(FactionName), ResourceType = typeof(App.Resources.Domain.MiniFaction))]
    public string FactionName { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(FactionDesc), Prompt = nameof(FactionDesc), ResourceType = typeof(App.Resources.Domain.MiniFaction))]
    public string FactionDesc { get; set; } = default!; 
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(Miniatures), Prompt = nameof(Miniatures), ResourceType = typeof(App.Resources.Domain.MiniFaction))]
    public ICollection<Miniature>? Miniatures { get; set; }
}