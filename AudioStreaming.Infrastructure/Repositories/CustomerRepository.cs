using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;

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
    return _context.Customers.Include(c => c.Subscription.Plan).ToList().FirstOrDefault(c => c.Email.Value == email);
  }
}
