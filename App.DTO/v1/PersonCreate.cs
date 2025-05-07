using System.ComponentModel.DataAnnotations;

namespace App.DTO.v1;

public class PersonCreate
{
    [Required]
    [MaxLength(128, ErrorMessageResourceType = typeof(Base.Resources.Common), ErrorMessageResourceName = "MaxLength")]
    public string PersonName { get; set; } = default!;
}