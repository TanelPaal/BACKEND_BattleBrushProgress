using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniState : BaseEntity
{
    [MaxLength(64, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(StateName), Prompt = nameof(StateName), ResourceType = typeof(App.Resources.Domain.MiniState))]
    public string StateName { get; set; } = default!;
    
    [Display(Name = nameof(StateDesc), Prompt = nameof(StateDesc), ResourceType = typeof(App.Resources.Domain.MiniState))]
    public string StateDesc { get; set; } = default!;
}