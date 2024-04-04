using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Infrastructure;

public class MusicRepository : RepositoryDefault<Music>
{
  private readonly ApplicationContext _context;

  public MusicRepository(ApplicationContext context) : base(context)
  {
    _context = context;
  }

  public Music GetById(string id)
  {
    return _context.Musics.Include(music => music.Album).Include(music => music.Album.Owner).FirstOrDefault(music => music.Id.ToString() == id);
  }

    public IList<Music> GetAll()
    {
        return _context.Set<Music>().Include(music => music.Album).ToList();
    }
}
