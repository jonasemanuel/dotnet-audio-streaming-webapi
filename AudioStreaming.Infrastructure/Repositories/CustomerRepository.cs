using AudioStreaming.Domain;

namespace AudioStreaming.Infrastructure;

public class CustomerRepository : RepositoryDefault<Customer>
{
  private readonly ApplicationContext _context;

  public CustomerRepository(ApplicationContext context) : base(context)
  {
    _context = context;
  }

  public Customer GetByEmail(string email)
  {
    return _context.Customers.FirstOrDefault(c => c.Email.Value == email);
  }
}
