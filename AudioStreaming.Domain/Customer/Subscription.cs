namespace AudioStreaming.Domain;

public class Subscription
{
  public Guid Id { get; set; }
  public bool IsActive { get; set; } = true;
  public DateTime CreatedAt { get; set; }
  public Plan? Plan { get; set; }

  public Subscription(Plan? plan)
  {
    Plan = plan;
  }

  public void ChangePlan(Plan? plan)
  {
    Plan = plan;
  }

  public void Activate()
  {
    IsActive = true;
  }

  public void DeActivate()
  {
    IsActive = false;
  }
}
