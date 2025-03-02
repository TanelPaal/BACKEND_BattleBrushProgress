using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class User : BaseEntity
{
    [MaxLength(128)]
    public string UserName { get; set; } = default!;

}