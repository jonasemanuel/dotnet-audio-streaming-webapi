namespace AudioStreaming.Domain;

public class Artist
{
  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public string ImageUrl { get; private set; }
  public List<Album> Album { get; private set; } = new List<Album>();

  public Artist(string name, string url)
  {
    Id = new Guid();
    Name = name;
    ImageUrl = url;
  }

  public void AddMusics(Album album, List<Music> musics)
  {
    Album selectedAlbum = Album.First(a => a.Id == album.Id);
    selectedAlbum.AddMusics(musics);
  }
}
