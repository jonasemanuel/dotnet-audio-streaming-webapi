namespace AudioStreaming.Domain;

public class Subscription
{
  public Guid Id { get; private set; }
  public bool IsActive { get; private set; } = true;
  public DateTime CreatedAt { get; private set; }
  public Plan Plan { get; private set; }

  public Subscription(Plan plan)
  {
    Plan = plan;
  }

  public void ChangePlan(Plan plan)
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
