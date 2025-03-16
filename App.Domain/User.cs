using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace App.Domain;

public class User : BaseEntity
{
    [MaxLength(128)]
    [Display(Name = nameof(UserName), Prompt = nameof(UserName), ResourceType = typeof(App.Resources.Domain.User))]
    public string UserName { get; set; } = default!;

}