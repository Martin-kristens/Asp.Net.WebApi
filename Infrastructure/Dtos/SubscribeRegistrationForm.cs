using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class SubscribeRegistrationForm
{
    [Required]
    public string Email { get; set; } = null!;
}
