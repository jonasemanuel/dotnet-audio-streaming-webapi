namespace AudioStreaming.Domain;

public class Music
{
  public readonly Guid Id;
  public string Name { get; private set; }

  public Music (string name)
  {
    Name = name;
  }
}
