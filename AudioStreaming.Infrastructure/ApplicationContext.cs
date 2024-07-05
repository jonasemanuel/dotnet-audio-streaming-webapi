using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AudioStreaming.Infrastructure;

public class ApplicationContext : DbContext
{
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Playlist> Playlists { get; set; }
  public DbSet<Subscription> Subscriptions { get; set; }

  public DbSet<Album> Albums { get; set; }
  public DbSet<Artist> Artists { get; set; }
  public DbSet<Music> Musics { get; set; }
  public DbSet<Plan> Plans { get; set; }

  public DbSet<CreditCard> CreditCards { get; set; }
  public DbSet<Transaction> Transactions { get; set; }

  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    base.OnModelCreating(modelBuilder);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
    base.OnConfiguring(optionsBuilder);
  }
}
