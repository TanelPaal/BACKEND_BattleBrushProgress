using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class UserPaints : BaseEntity
{
    [Required]
    public int Quantity { get; set; }
    
    public DateTime AcquisitionDate { get; set; }
    
    // Relationships
    public Guid UserId { get; set; }
    public Guid PaintId { get; set; }
    public Paint? Paint { get; set; }
    
    public ICollection<MiniPaintSwatch>? MiniPaintSwatches { get; set; }
}