using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniProperties : BaseEntity
{
    [MaxLength(64)]
    public string PropertyName { get; set; } = default!;
    
    public string PropertyDesc { get; set; } = default!;
    
    public ICollection<Miniature>? Miniatures { get; set; }
}