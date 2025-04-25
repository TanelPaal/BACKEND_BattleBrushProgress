using System.ComponentModel.DataAnnotations;
using App.Domain.Identity;
using Base.Domain;

namespace App.Domain;

public class PersonPaints : BaseEntity
{
    [Required]
    [Display(Name = nameof(Quantity), Prompt = nameof(Quantity), ResourceType = typeof(App.Resources.Domain.PersonPaints))]
    public int Quantity { get; set; }
    
    private DateTime _acquisitionDate = DateTime.UtcNow;

    [Display(Name = nameof(AcquisitionDate), Prompt = nameof(AcquisitionDate), ResourceType = typeof(App.Resources.Domain.PersonPaints))]
    public DateTime AcquisitionDate
    {
        get => _acquisitionDate; 
        set => _acquisitionDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    
    // Relationships
    [Display(Name = nameof(Person), Prompt = nameof(Person), ResourceType = typeof(App.Resources.Domain.PersonPaints))]
    public Guid PersonId { get; set; }
    
    [Display(Name = nameof(Person), Prompt = nameof(Person), ResourceType = typeof(App.Resources.Domain.PersonPaints))]
    public Person? Person { get; set; }
    
    [Display(Name = nameof(Paint), Prompt = nameof(Quantity), ResourceType = typeof(App.Resources.Domain.PersonPaints))]
    public Guid PaintId { get; set; }
    
    [Display(Name = nameof(Paint), Prompt = nameof(Paint), ResourceType = typeof(App.Resources.Domain.PersonPaints))]
    public Paint? Paint { get; set; }
    
    public ICollection<MiniPaintSwatch>? MiniPaintSwatches { get; set; }
    
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}