using System.ComponentModel.DataAnnotations;

namespace App.DAL.DTO;

public class MiniFaction
{
    [MaxLength(256)]
    [Display(Name = nameof(FactionName), Prompt = nameof(FactionName), ResourceType = typeof(App.Resources.Domain.MiniFaction))]
    public string FactionName { get; set; } = default!;
    
    [Display(Name = nameof(FactionDesc), Prompt = nameof(FactionDesc), ResourceType = typeof(App.Resources.Domain.MiniFaction))]
    public string FactionDesc { get; set; } = default!; 
    
    public ICollection<Miniature>? Miniatures { get; set; }
}