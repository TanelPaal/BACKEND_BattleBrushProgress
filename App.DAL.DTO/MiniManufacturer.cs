using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.DAL.DTO;

public class MiniManufacturer : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(ManufacturerName), Prompt = nameof(ManufacturerName), ResourceType = typeof(App.Resources.Domain.MiniManufacturer))]
    public string ManufacturerName { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(HeadquartersLocation), Prompt = nameof(HeadquartersLocation), ResourceType = typeof(App.Resources.Domain.MiniManufacturer))]
    public string HeadquartersLocation { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(ContactEmail), Prompt = nameof(ContactEmail), ResourceType = typeof(App.Resources.Domain.MiniManufacturer))]
    public string ContactEmail { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(ContactPhone), Prompt = nameof(ContactPhone), ResourceType = typeof(App.Resources.Domain.MiniManufacturer))]
    public string ContactPhone { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(Miniatures), Prompt = nameof(Miniatures), ResourceType = typeof(App.Resources.Domain.MiniManufacturer))]
    public ICollection<Miniature>? Miniatures { get; set; }
}