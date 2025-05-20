using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class PersonPaints : IDomainId
{
    public Guid Id { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    private DateTime _acquisitionDate = DateTime.UtcNow;
    
    public DateTime AcquisitionDate
    {
        get => _acquisitionDate; 
        set => _acquisitionDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    
    // Relationships
    public Guid PersonId { get; set; }
    public Person? Person { get; set; }
    
    public Guid PaintId { get; set; }
    public Paint? Paint { get; set; }
}