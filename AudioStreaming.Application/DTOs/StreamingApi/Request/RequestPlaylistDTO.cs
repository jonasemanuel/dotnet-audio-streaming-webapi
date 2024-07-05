namespace AudioStreaming.Application;

public class RequestPlaylistDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string OwnerId { get; set; }
    public List<RequestMusicDTO> Musics { get; set; }
}
