using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniFaction : BaseEntity
{
    [MaxLength(256)]
    public string FactionName { get; set; } = default!;
    
    public string FactionDesc { get; set; } = default!; 
    
    public ICollection<Miniature>? Miniatures { get; set; }
}