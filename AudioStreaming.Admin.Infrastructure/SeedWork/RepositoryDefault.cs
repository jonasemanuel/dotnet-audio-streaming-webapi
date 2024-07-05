using AudioStreaming.Domain;
using AudioStreaming.Infrastructure;

namespace AudioStreaming.Admin.Infrastructure;

public class RepositoryDefault<T> : IRepositoryDefault<T> where T : class, IEntity
{
    private readonly AdminContext _context;

    public RepositoryDefault(AdminContext context)
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
