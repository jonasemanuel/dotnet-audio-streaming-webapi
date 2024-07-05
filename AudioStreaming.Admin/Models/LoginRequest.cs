using System.ComponentModel.DataAnnotations;

namespace AudioStreaming.Admin;

public class LoginRequest
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string Password { get; set; }
}
