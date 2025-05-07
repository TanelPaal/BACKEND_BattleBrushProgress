using System.ComponentModel.DataAnnotations;

namespace App.DTO.v1;

public class BrandCreate
{
    [MaxLength(256)]
    public string BrandName { get; set; } = default!;
    
    [MaxLength(256)]
    public string HeadquartersLocation { get; set; } = default!;
    
    [MaxLength(256)]
    public string ContactEmail { get; set; } = default!;
    
    [MaxLength(256)]
    public string ContactPhone { get; set; } = default!;
}