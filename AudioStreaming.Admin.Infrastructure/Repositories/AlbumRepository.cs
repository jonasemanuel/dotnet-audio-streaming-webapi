using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;

namespace AudioStreaming.Admin.Infrastructure;

public class AlbumRepository : RepositoryDefault<Album>
{
    private readonly AdminContext _context;

    public AlbumRepository(AdminContext context) : base(context)
    {
        _context = context;
    }

    public Album GetById(string id)
    {
        return _context.Albums.Include(album => album.Owner).FirstOrDefault(album => album.Id.ToString() == id);
    }

    public IList<Album> GetAll()
    {
        return _context.Set<Album>().Include(album => album.Owner).ToList();
    }

    public void Save(Album album)
    {
        _context.Albums.Add(album);
        _context.SaveChanges();
    }
}
