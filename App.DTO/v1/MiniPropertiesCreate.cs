using System.ComponentModel.DataAnnotations;

namespace App.DTO.v1;

public class MiniPropertiesCreate
{
    [MaxLength(64)]
    public string PropertyName { get; set; } = default!;
    
    public string PropertyDesc { get; set; } = default!;
}