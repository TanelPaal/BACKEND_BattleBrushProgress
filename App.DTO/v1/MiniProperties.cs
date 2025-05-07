using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class MiniProperties : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(64)]
    public string PropertyName { get; set; } = default!;
    
    public string PropertyDesc { get; set; } = default!;

}