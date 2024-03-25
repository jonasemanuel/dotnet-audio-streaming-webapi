namespace AudioStreaming.Domain;

public record Merchant
{
  public string Name { get; set; }

  public Merchant(string name)
  {
    Name = name;
  }
}
