using System.ComponentModel.DataAnnotations;

namespace App.DTO.v1;

public class MiniFactionCreate
{
    [MaxLength(256)]
    public string FactionName { get; set; } = default!;
    
    public string FactionDesc { get; set; } = default!;
}