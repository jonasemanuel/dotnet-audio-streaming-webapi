using AudioStreaming.Domain;

namespace AudioStreaming.Infrastructure;

public class ArtistRepository : RepositoryDefault<Artist>
{
    private readonly ApplicationContext _context;

    public ArtistRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }
}
