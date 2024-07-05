using System.ComponentModel.DataAnnotations;

namespace AudioStreaming.Admin;

public class ArtistRequest
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string ImageUrl { get; set; }
}
