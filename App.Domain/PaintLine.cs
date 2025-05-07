using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class PaintLine : BaseEntity
{
    [MaxLength(128, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(PaintLineName), Prompt = nameof(PaintLineName), ResourceType = typeof(App.Resources.Domain.PaintLine))]
    public string PaintLineName { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(Description), Prompt = nameof(Description), ResourceType = typeof(App.Resources.Domain.PaintLine))]
    public string Description { get; set; } = default!;
    
    // Add Relationship
    [Display(Name = nameof(Brand), Prompt = nameof(Brand), ResourceType = typeof(App.Resources.Domain.PaintLine))]
    public Guid BrandId { get; set; }
    [Display(Name = nameof(Brand), Prompt = nameof(Brand), ResourceType = typeof(App.Resources.Domain.PaintLine))]
    public Brand? Brand { get; set; }
    
}