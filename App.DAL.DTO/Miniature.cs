using System.ComponentModel.DataAnnotations;
using App.Resources.Domain;
using Base.Contracts;

namespace App.DAL.DTO;

public class Miniature : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(MiniName), Prompt = nameof(MiniName), ResourceType = typeof(App.Resources.Domain.Miniature))]
    public string MiniName { get; set; } = default!;
    
    [Display(Name = nameof(MiniDesc), Prompt = nameof(MiniDesc), ResourceType = typeof(App.Resources.Domain.Miniature))]
    public string MiniDesc { get; set; } = default!;
    
    // Relationships
    [Display(Name = nameof(MiniFaction), Prompt = nameof(MiniFaction), ResourceType = typeof(App.Resources.Domain.Miniature))]
    public Guid MiniFactionId { get; set; }
    [Display(Name = nameof(MiniFaction), Prompt = nameof(MiniFaction), ResourceType = typeof(App.Resources.Domain.Miniature))]
    public MiniFaction? MiniFaction { get; set; }
    
    [Display(Name = nameof(MiniProperties), Prompt = nameof(MiniProperties), ResourceType = typeof(App.Resources.Domain.Miniature))]
    public Guid MiniPropertiesId { get; set; }
    [Display(Name = nameof(MiniProperties), Prompt = nameof(MiniProperties), ResourceType = typeof(App.Resources.Domain.Miniature))]
    public MiniProperties? MiniProperties { get; set; }
    
    [Display(Name = nameof(MiniManufacturer), Prompt = nameof(MiniManufacturer), ResourceType = typeof(App.Resources.Domain.Miniature))]
    public Guid MiniManufacturerId { get; set; }
    [Display(Name = nameof(MiniManufacturer), Prompt = nameof(MiniManufacturer), ResourceType = typeof(App.Resources.Domain.Miniature))]
    public MiniManufacturer? MiniManufacturer { get; set; }
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(MiniatureCollections), Prompt = nameof(MiniatureCollections), ResourceType = typeof(App.Resources.Domain.Miniature))]
    public ICollection<MiniatureCollection>? MiniatureCollections { get; set; }
}