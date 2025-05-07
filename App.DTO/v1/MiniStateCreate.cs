using System.ComponentModel.DataAnnotations;

namespace App.DTO.v1;

public class MiniStateCreate
{
    [MaxLength(64)]
    public string StateName { get; set; } = default!;
    
    public string StateDesc { get; set; } = default!;
}