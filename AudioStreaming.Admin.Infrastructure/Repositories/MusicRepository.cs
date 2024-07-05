using AudioStreaming.Domain;
using AudioStreaming.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Admin.Infrastructure;

public class MusicRepository : RepositoryDefault<Music>
{
  private readonly AdminContext _context;

  public MusicRepository(AdminContext context) : base(context)
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
