using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Infrastructure;

public class PlaylistRepository : RepositoryDefault<Playlist>
{

    private readonly ApplicationContext _context;
    public PlaylistRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public Playlist GetById(string id)
    {
        return _context.Playlists.Include(playlist => playlist.Musics).FirstOrDefault(playlist => playlist.Id.ToString() == id);
    }
}
