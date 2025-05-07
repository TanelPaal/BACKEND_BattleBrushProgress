using System.ComponentModel.DataAnnotations;
using Base.Contracts;

namespace App.BLL.DTO;

public class Paint : IDomainId
{
    public Guid Id { get; set; }
    
    [MaxLength(128, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(Name), Prompt = nameof(Name), ResourceType = typeof(App.Resources.Domain.Paint))]
    public string Name { get; set; } = default!;
    
    [MaxLength(7, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(HexCode), Prompt = nameof(HexCode), ResourceType = typeof(App.Resources.Domain.Paint))]
    public string HexCode { get; set; } = default!;
    
    [MaxLength(12, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(UPC), Prompt = nameof(UPC), ResourceType = typeof(App.Resources.Domain.Paint))]
    public string UPC { get; set; } = default!; // Universal Product Code
    
    // Add relationships
    [Display(Name = nameof(Brand), Prompt = nameof(Brand), ResourceType = typeof(App.Resources.Domain.Paint))]
    public Guid BrandId { get; set; }
    [Display(Name = nameof(Brand), Prompt = nameof(Brand), ResourceType = typeof(App.Resources.Domain.Paint))]
    public Brand? Brand { get; set; }
    
    [Display(Name = nameof(PaintType), Prompt = nameof(PaintType), ResourceType = typeof(App.Resources.Domain.Paint))]
    public Guid PaintTypeId { get; set; }
    [Display(Name = nameof(PaintType), Prompt = nameof(PaintType), ResourceType = typeof(App.Resources.Domain.Paint))]
    public PaintType? PaintType { get; set; }
    
    [Display(Name = nameof(PaintLine), Prompt = nameof(PaintLine), ResourceType = typeof(App.Resources.Domain.Paint))]
    public Guid? PaintLineId { get; set; }
    [Display(Name = nameof(PaintLine), Prompt = nameof(PaintLine), ResourceType = typeof(App.Resources.Domain.Paint))]
    public PaintLine? PaintLine { get; set; }
    
    // Navigation property for UserPaints
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(PersonPaints), Prompt = nameof(PersonPaints), ResourceType = typeof(App.Resources.Domain.Paint))]
    public ICollection<PersonPaints>? PersonPaints { get; set; }
}