namespace AudioStreaming.Domain;

public class Artist : IEntity
{
  public Guid Id { get; set; }
  public string Name { get; private set; }
  public string ImageUrl { get; private set; }
  public List<Album> Albums { get; private set; } = new List<Album>();

  public Artist() {}

  public Artist(string name, string url)
  {
    Id = new Guid();
    Name = name;
    ImageUrl = url;
  }

  public void AddMusics(string albumName, List<Music> musics)
  {
    Album selectedAlbum = Albums.Where(a => a.Name == albumName).First();
    selectedAlbum?.AddMusics(musics);
  }

  public void CreateAlbum(string name, string imageUrl)
  {
    if(Albums.Where(a => a.Name.ToLower() == name.ToLower()).Count() > 0)
    {
      throw new Exception("There is already one with that name");
    }

    Album album = new Album(name, this, imageUrl);
    Albums.Add(album);
  }
}
