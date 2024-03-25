using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Infrastructure;

public class AlbumRepository : RepositoryDefault<Album>
{
    private readonly ApplicationContext _context;

    public AlbumRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public Album GetById(string id)
    {
        return _context.Albums.Include(album => album.Owner).FirstOrDefault(album => album.Id.ToString() == id);
    }
}
