using System.ComponentModel.DataAnnotations;

namespace App.DAL.DTO;

public class Person
{
    [MaxLength(128)]
    [Display(Name = nameof(App.Resources.Domain.Person.UserName), Prompt = nameof(App.Resources.Domain.Person.UserName), ResourceType = typeof(App.Resources.Domain.Person))]
    public string PersonName { get; set; } = default!;
    
    public ICollection<PersonPaints>? PersonPaints { get; set; }
    public ICollection<MiniatureCollection>? MiniatureCollections { get; set; }
}