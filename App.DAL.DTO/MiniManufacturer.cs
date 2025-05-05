using System.ComponentModel.DataAnnotations;

namespace App.DAL.DTO;

public class MiniManufacturery
{
    [MaxLength(256)]
    [Display(Name = nameof(ManufacturerName), Prompt = nameof(ManufacturerName), ResourceType = typeof(App.Resources.Domain.MiniManufacturer))]
    public string ManufacturerName { get; set; } = default!;
    
    [MaxLength(256)]
    [Display(Name = nameof(HeadquartersLocation), Prompt = nameof(HeadquartersLocation), ResourceType = typeof(App.Resources.Domain.MiniManufacturer))]
    public string HeadquartersLocation { get; set; } = default!;
    
    [MaxLength(256)]
    [Display(Name = nameof(ContactEmail), Prompt = nameof(ContactEmail), ResourceType = typeof(App.Resources.Domain.MiniManufacturer))]
    public string ContactEmail { get; set; } = default!;
    
    [MaxLength(256)]
    [Display(Name = nameof(ContactPhone), Prompt = nameof(ContactPhone), ResourceType = typeof(App.Resources.Domain.MiniManufacturer))]
    public string ContactPhone { get; set; } = default!;
    
    public ICollection<Miniature>? Miniatures { get; set; }
}