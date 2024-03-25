namespace AudioStreaming.Domain;

public class Customer : IEntity
{
  public Guid Id { get; set; }
  public string Name { get; private set; }
  public Email Email { get; private set; }
  public Password Password { get; private set; }
  public Gender Gender { get; private set; }
  public DateOnly BornDate { get; private set; }
  public bool IsActive { get; private set; }
  public List<Playlist> Playlists { get; private set; } = new List<Playlist>();
  public Subscription Subscription { get; private set; }
  public List<CreditCard> CreditCards { get; private set; } = new List<CreditCard>();

  public Customer() {}

  public Customer (string name, string email, string password, Gender gender, Plan plan) {
    Customer customer = new Customer
    {
        Id = new Guid(),
        Name = name,
        Gender = gender
    };

    Playlist favoritesMusicsPlaylist = new Playlist("Músicas Favoritas", "Minhas músicas favoritas", customer);
    Email = new Email(email);
    Password = new Password(password);
    this.Playlists.Add(favoritesMusicsPlaylist);
    this.SubscribePlan(plan);
    this.Activate();
  }

  public void ChangeEmail(string email)
  {
    Email = new Email(email);
  }

  public void ChangeName(string name)
  {
    Name = name;
  }

  public void ChangePassword(string password)
  {
    Password = new Password(password);
  }

  public void ChangeGender(Gender gender)
  {
    Gender = gender;
  }

  public void CreatePlaylist(Playlist playlist)
  {
    Playlists.Add(playlist);
  }

  public void SubscribePlan(Plan plan) {
    Subscription = new Subscription(plan);
  } 

  public void Activate()
  {
    IsActive = true;
  }

  public void DeActivate()
  {
    IsActive = false;
  }

  public void ChangeBornDate(DateOnly date)
  {
    BornDate = date;
  }

  public void AddCreditCard(CreditCard creditCard)
  {
    CreditCards.Add(creditCard);
  }
}
