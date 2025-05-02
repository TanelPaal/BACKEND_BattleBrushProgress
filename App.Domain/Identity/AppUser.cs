using Base.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Identity;

public class AppUser : BaseUser<AppUserRole>
{
    public ICollection<Person>? Persons { get; set; }
    public ICollection<MiniatureCollection>? MiniatureCollections { get; set; }
    public ICollection<PersonPaints>? PersonPaints { get; set; }
    public ICollection<MiniPaintSwatch>? MiniPaintSwatches { get; set; }
}