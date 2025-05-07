using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class MiniFaction : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(256)]
    public string FactionName { get; set; } = default!;
    
    public string FactionDesc { get; set; } = default!; 
    
}