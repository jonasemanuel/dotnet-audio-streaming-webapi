using AudioStreaming.Domain;

namespace AudioStreaming.Infrastructure;

public class PlanRepository : RepositoryDefault<Plan>
{
    private readonly ApplicationContext _context;

    public PlanRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }
}