using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DAL.DTO;

public class PaintLine : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(128)]
    [Display(Name = nameof(PaintLineName), Prompt = nameof(PaintLineName), ResourceType = typeof(App.Resources.Domain.PaintLine))]
    public string PaintLineName { get; set; } = default!;
    
    [MaxLength(256)]
    [Display(Name = nameof(Description), Prompt = nameof(Description), ResourceType = typeof(App.Resources.Domain.PaintLine))]
    public string Description { get; set; } = default!;
    
    // Add Relationship
    [Display(Name = nameof(Brand), Prompt = nameof(Brand), ResourceType = typeof(App.Resources.Domain.PaintLine))]
    public Guid BrandId { get; set; }
    [Display(Name = nameof(Brand), Prompt = nameof(Brand), ResourceType = typeof(App.Resources.Domain.PaintLine))]
    public Brand? Brand { get; set; }
}