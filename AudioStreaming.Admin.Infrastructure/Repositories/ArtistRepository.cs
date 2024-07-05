using AudioStreaming.Domain;

namespace AudioStreaming.Admin.Infrastructure;

public class ArtistRepository : RepositoryDefault<Artist>
{
    private readonly AdminContext _context;

    public ArtistRepository(AdminContext context) : base(context)
    {
        _context = context;
    }
}
