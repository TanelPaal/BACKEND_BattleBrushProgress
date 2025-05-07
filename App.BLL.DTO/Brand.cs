using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.BLL.DTO;

public class Brand : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(BrandName), Prompt = nameof(BrandName), ResourceType = typeof(App.Resources.Domain.Brand))]
    public string BrandName { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(HeadquartersLocation), Prompt = nameof(HeadquartersLocation), ResourceType = typeof(App.Resources.Domain.Brand))]
    public string HeadquartersLocation { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(ContactEmail), Prompt = nameof(ContactEmail), ResourceType = typeof(App.Resources.Domain.Brand))]
    public string ContactEmail { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(ContactPhone), Prompt = nameof(ContactPhone), ResourceType = typeof(App.Resources.Domain.Brand))]
    public string ContactPhone { get; set; } = default!;
    
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(Paints), Prompt = nameof(Paints), ResourceType = typeof(App.Resources.Domain.Brand))]
    public ICollection<Paint>? Paints { get; set; }
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(PaintLines), Prompt = nameof(PaintLines), ResourceType = typeof(App.Resources.Domain.Brand))]
    public ICollection<PaintLine>? PaintLines { get; set; }
}