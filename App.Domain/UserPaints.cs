using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class UserPaints : BaseEntity
{
    [Required]
    [Display(Name = nameof(Quantity), Prompt = nameof(Quantity), ResourceType = typeof(App.Resources.Domain.UserPaints))]
    public int Quantity { get; set; }
    
    [Display(Name = nameof(AcquisitionDate), Prompt = nameof(AcquisitionDate), ResourceType = typeof(App.Resources.Domain.UserPaints))]
    public DateTime AcquisitionDate { get; set; }
    
    // Relationships
    [Display(Name = nameof(User), Prompt = nameof(User), ResourceType = typeof(App.Resources.Domain.UserPaints))]
    public Guid UserId { get; set; }
    
    [Display(Name = nameof(Paint), Prompt = nameof(Quantity), ResourceType = typeof(App.Resources.Domain.UserPaints))]
    public Guid PaintId { get; set; }
    
    [Display(Name = nameof(Paint), Prompt = nameof(Paint), ResourceType = typeof(App.Resources.Domain.UserPaints))]
    public Paint? Paint { get; set; }
    
    public ICollection<MiniPaintSwatch>? MiniPaintSwatches { get; set; }
}