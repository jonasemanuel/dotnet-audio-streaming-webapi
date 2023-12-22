namespace AudioStreaming.Domain;

public class Music
{
  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public int Duration { get; private set; }
  public DateTime CreatedAt { get; private set; }

  public Music (string name, int duration)
  {
    Id = new Guid();
    Name = name;
    Duration = duration;
    CreatedAt = DateTime.Now;
  }
}
