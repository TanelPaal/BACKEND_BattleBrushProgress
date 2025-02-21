using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Person : BaseEntity
{
    [MaxLength (128)]
    public string PersonName { get; set; } = default!;
}