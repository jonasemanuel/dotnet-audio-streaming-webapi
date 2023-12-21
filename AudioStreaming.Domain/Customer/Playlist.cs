namespace AudioStreaming.Domain;

public class Playlist
{
  public  Guid Id { get; private set; }
  public  string Name { get; private set; }
  public string Description { get; private set; }
  public  Customer Owner { get; private set; }
  public  List<Music> Musics { get; private set; } = new List<Music>();
  public  DateTime CreatedAt { get; private set; }

  public Playlist(string name, string description, Customer owner)
  {
    Id = new Guid();
    Name = name;
    Description = description;
    Owner = owner;
    CreatedAt = DateTime.Now;
  }
  
  public void ChangeName(string name)
  {
    Name = name;
  }

  public void ChangeDescription(string description)
  {
    Description = description;
  }

  public void AddMusics(List<Music> musics)
  {
    Musics.AddRange(musics);
  }

  public void RemoveMusic(Music music){
    Musics.Remove(music);
  }
}
