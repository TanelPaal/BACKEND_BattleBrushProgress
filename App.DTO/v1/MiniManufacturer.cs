using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DTO.v1;

public class MiniManufacturer : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(256)]
    public string ManufacturerName { get; set; } = default!;
    
    [MaxLength(256)]
    public string HeadquartersLocation { get; set; } = default!;
    
    [MaxLength(256)]
    public string ContactEmail { get; set; } = default!;
    
    [MaxLength(256)]
    public string ContactPhone { get; set; } = default!;
    
}