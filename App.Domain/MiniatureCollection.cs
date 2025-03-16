using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniatureCollection : BaseEntity
{
    [MaxLength(256)]
    [Display(Name = nameof(CollectionName), Prompt = nameof(CollectionName), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public string CollectionName { get; set; } = default!;
    
    [Display(Name = nameof(CollectionDesc), Prompt = nameof(CollectionDesc), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public string CollectionDesc { get; set; } = default!;
    
    [Display(Name = nameof(AcquisitionDate), Prompt = nameof(AcquisitionDate), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public DateTime AcquisitionDate { get; set; }
    
    [Display(Name = nameof(CompletionDate), Prompt = nameof(CompletionDate), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public DateTime? CompletionDate { get; set; }
    
    // Relationships
    [Display(Name = nameof(Miniature), Prompt = nameof(Miniature), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public Guid MiniatureId { get; set; }
    [Display(Name = nameof(Miniature), Prompt = nameof(Miniature), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public Miniature? Miniature { get; set; }
    
    [Display(Name = nameof(MiniState), Prompt = nameof(MiniState), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public Guid MiniStateId { get; set; }
    [Display(Name = nameof(MiniState), Prompt = nameof(MiniState), ResourceType = typeof(App.Resources.Domain.MiniatureCollection))]
    public MiniState? MiniState { get; set; }
    
    public ICollection<MiniPaintSwatch>? MiniPaintSwatches { get; set; }
}