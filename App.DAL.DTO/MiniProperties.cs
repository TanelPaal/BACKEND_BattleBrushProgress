using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DAL.DTO;

public class MiniProperties : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(64)]
    [Display(Name = nameof(PropertyName), Prompt = nameof(PropertyName), ResourceType = typeof(App.Resources.Domain.MiniProperties))]
    public string PropertyName { get; set; } = default!;
    
    [Display(Name = nameof(PropertyDesc), Prompt = nameof(PropertyDesc), ResourceType = typeof(App.Resources.Domain.MiniProperties))]
    public string PropertyDesc { get; set; } = default!;
    
    public ICollection<Miniature>? Miniatures { get; set; }
}