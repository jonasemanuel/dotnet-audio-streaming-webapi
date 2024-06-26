﻿namespace AudioStreaming.Domain;

public class Playlist : IEntity
{
  public  Guid Id { get; set; }
  public  string Name { get; private set; }
  public string Description { get; private set; }
  public  Customer Owner { get; private set; }
  public  List<Music> Musics { get; private set; } = new List<Music>();
  public  DateTime CreatedAt { get; private set; }
  public bool IsPublic { get; private set; } = true;

  public Playlist() {}

  public Playlist(string name, string description, Customer owner, bool isPublic = true)
  {
    Id = new Guid();
    Name = name;
    Description = description;
    Owner = owner;
    CreatedAt = DateTime.UtcNow;
    IsPublic = isPublic;
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
