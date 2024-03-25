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
    return _context.Musics.Include(music => music.Album).FirstOrDefault(music => music.Id.ToString() == id);
  }
}
