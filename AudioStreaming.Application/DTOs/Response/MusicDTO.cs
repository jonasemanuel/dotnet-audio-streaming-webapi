namespace AudioStreaming.Application;

public class ResponseMusicDTO
{
  public string Id { get; set; }
  public string Name { get; set; }
  public int Duration { get; set; }
  public ResponseAlbumDTO Album { get; set; }
}
