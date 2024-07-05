using AudioStreaming.Admin.Infrastructure;
using AudioStreaming.Domain;

namespace AudioStreaming.Admin.Infrastructure;

public class UserRepository
{
    private readonly AdminContext _context;
    public UserRepository(AdminContext context)
    {
        _context = context;
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User GetByEmailAndPassword(string email, string password)
    {
        return _context.Users.ToList().FirstOrDefault(x => x.Email.Value == email && x.Password.Value == password && x.Role == Role.Admin);
    }
}
