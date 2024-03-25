namespace AudioStreaming.Domain;

public class Album : IEntity
{
  public Guid Id { get; set; }
  public string Name { get; private set; }
  public string ImageUrl { get; set; }
  public List<Music> Musics { get; private set; } = new List<Music>();
  public Artist Owner { get; private set; }

  public Album() {}

  public Album(string name, Artist owner, string imageUrl)
  {
    Id = new Guid();
    Name = name;
    Owner = owner;
    ImageUrl = imageUrl;
  }

  public void AddMusics(List<Music> musics)
  {
    Musics.AddRange(musics);
  }
}
