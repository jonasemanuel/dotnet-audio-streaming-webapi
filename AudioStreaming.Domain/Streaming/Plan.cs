namespace AudioStreaming.Domain;

public class Plan
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }

  public Plan(string name, decimal price) {
    Name = name;
    Price = price;
  }
}
