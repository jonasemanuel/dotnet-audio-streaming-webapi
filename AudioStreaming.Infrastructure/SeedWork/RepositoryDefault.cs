using AudioStreaming.Domain;

namespace AudioStreaming.Infrastructure;

public class RepositoryDefault<T> : IRepositoryDefault<T> where T : class, IEntity
{
    private readonly ApplicationContext _context;

    public RepositoryDefault(ApplicationContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public IList<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(string id)
    {
      return _context.Set<T>().Where(entity => entity.Id.ToString() == id).FirstOrDefault();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }
}
