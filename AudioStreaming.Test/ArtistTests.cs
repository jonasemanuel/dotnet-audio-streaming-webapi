using AudioStreaming.Domain;

namespace AudioStreaming.Test;

public class ArtistTests
{
  [Fact]
  public void ShouldAddMusicCorrectly()
  {
    Artist artist = new Artist("Michael Jackson", "profile.png");
    artist.CreateAlbum("Thriller", "album.png");

    List<Music> musicsToAdd = new List<Music>
    {
        new Music("Black or White", 2000, artist.Albums.First())
    };

    artist.AddMusics("Thriller", musicsToAdd);

    Assert.True(artist.Albums.Count() == 1);
    Assert.True(artist.Albums.First().Musics.First().Name == "Black or White");
  }
}
