namespace AudioStreaming.Domain;

public class Music : IEntity
{
  public Guid Id { get; set; }
  public string Name { get; private set; }
  public int Duration { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public Album Album { get; private set; }

  public Music() {}

  public Music (string name, int duration, Album album)
  {
    Id = new Guid();
    Name = name;
    Duration = duration;
    CreatedAt = DateTime.Now;
    Album = album;
  }
}
