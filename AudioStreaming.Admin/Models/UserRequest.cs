using System.ComponentModel.DataAnnotations;

namespace AudioStreaming.Admin;

public class UserRequest
{
    [Required(ErrorMessage = "Campo obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string Role { get; set; }
}
