using System.ComponentModel.DataAnnotations;

namespace Domain;

public class ContactType
{
    [MaxLength (128)]
    public string ContactTypeName { get; set; } = default!;
}