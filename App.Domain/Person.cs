using System.ComponentModel.DataAnnotations;
using App.Domain.Identity;
using Base.Domain;

namespace App.Domain;

public class Person : BaseEntityUser<AppUser>
{
    [MaxLength(128, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    [Display(Name = nameof(App.Resources.Domain.Person.UserName), Prompt = nameof(App.Resources.Domain.Person.UserName), ResourceType = typeof(App.Resources.Domain.Person))]
    public string PersonName { get; set; } = default!;
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    public ICollection<PersonPaints>? PersonPaints { get; set; }
    
    [MaxLength(256, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    public ICollection<MiniatureCollection>? MiniatureCollections { get; set; }
    
}