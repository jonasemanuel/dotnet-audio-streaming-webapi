using System.ComponentModel.DataAnnotations;

namespace AudioStreaming.Admin;

public class MusicRequest
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public int Duration { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public Guid AlbumId { get; set; }
}
