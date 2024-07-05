namespace AudioStreaming.Application;

public class ResponseArtistDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public List<ResponseAlbumDTO> Albums { get; set; }
}
