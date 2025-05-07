using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.BLL.DTO;

public class MiniFaction : IDomainId
{
    public Guid Id { get; set; }
    
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