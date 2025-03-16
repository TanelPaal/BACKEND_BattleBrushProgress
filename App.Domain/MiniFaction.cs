using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniFaction : BaseEntity
{
    [MaxLength(256)]
    [Display(Name = nameof(FactionName), Prompt = nameof(FactionName), ResourceType = typeof(App.Resources.Domain.MiniFaction))]
    public string FactionName { get; set; } = default!;
    
    [Display(Name = nameof(FactionDesc), Prompt = nameof(FactionDesc), ResourceType = typeof(App.Resources.Domain.MiniFaction))]
    public string FactionDesc { get; set; } = default!; 
    
    public ICollection<Miniature>? Miniatures { get; set; }
}