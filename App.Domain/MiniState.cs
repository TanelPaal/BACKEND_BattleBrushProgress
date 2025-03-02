using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class MiniState : BaseEntity
{
    [MaxLength(64)]
    public string StateName { get; set; } = default!;
    
    public string StateDesc { get; set; } = default!;
}