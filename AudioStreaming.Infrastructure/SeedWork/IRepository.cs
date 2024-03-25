namespace AudioStreaming.Infrastructure;

public interface IRepositoryDefault<T> where T : class
{
    T GetById(string id);
    IList<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
