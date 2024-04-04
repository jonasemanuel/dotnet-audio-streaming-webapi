namespace AudioStreaming.Application;

public class ResponsePlaylistDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string OwnerId { get; set; }
    public List<ResponseMusicDTO> Musics { get; set; }
}
