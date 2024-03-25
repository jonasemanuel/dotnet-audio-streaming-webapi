namespace AudioStreaming.Domain;

public class Subscription : IEntity
{
  public Guid Id { get; set; }
  public bool IsActive { get; private set; } = true;
  public DateTime CreatedAt { get; private set; }
  public Plan Plan { get; private set; }

  public Subscription() {}

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
