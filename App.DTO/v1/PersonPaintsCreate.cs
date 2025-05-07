using System.ComponentModel.DataAnnotations;

namespace App.DTO.v1;

public class PersonPaintsCreate
{
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
    
    public Guid PaintId { get; set; }
}