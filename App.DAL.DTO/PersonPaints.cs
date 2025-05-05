using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DAL.DTO;

public class PersonPaints : IDomainId
{
    public Guid Id { get; set; }
    
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
}