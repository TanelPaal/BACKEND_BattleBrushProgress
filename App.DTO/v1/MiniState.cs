using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class MiniState : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(64)]
    public string StateName { get; set; } = default!;
    
    public string StateDesc { get; set; } = default!;
}