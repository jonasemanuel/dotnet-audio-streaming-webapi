namespace AudioStreaming.Domain;

public class Customer
{
  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public Email Email { get; private set; }
  public Password Password { get; private set; }
  public Gender Gender { get; private set; }
  public DateOnly BornDate { get; private set; }
  public bool IsActive { get; private set; }
  public List<Playlist> Playlists { get; private set; } = new List<Playlist>();
  public Subscription Subscription { get; private set; } = new Subscription(null);

  public static Customer Create(string name, string email, string password, Gender gender, Plan? plan) {
    Customer customer = new Customer
    {
        Id = new Guid(),
        Name = name,
        Gender = gender
    };

    Playlist favoritesMusicsPlaylist = Playlist.Create("Músicas Favoritas", new List<Music>(), customer);
    
    customer.ChangeEmail(email);
    customer.ChangePassword(password);

    customer.CreatePlaylist(new Playlist());
    customer.CreatePlaylist(favoritesMusicsPlaylist);
    
    customer.SubscribePlan(plan);

    return customer;
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

  public void SubscribePlan(Plan? plan) {
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
}
