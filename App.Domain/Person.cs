using System.ComponentModel.DataAnnotations;
using App.Domain.Identity;
using Base.Domain;

namespace App.Domain;

public class Person : BaseEntityUser<AppUser, AppRole>
{
    [MaxLength(128)]
    [Display(Name = nameof(App.Resources.Domain.Person.UserName), Prompt = nameof(App.Resources.Domain.Person.UserName), ResourceType = typeof(App.Resources.Domain.Person))]
    public string PersonName { get; set; } = default!;
    
    public ICollection<PersonPaints>? PersonPaints { get; set; }
    public ICollection<MiniatureCollection>? MiniatureCollections { get; set; }
    
    // public Guid AppUserId { get; set; }
    // public AppUser? AppUser { get; set; }

}