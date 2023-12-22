using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AudioStreaming.Infrastructure;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Gender).IsRequired();
        builder.Property(x => x.BornDate).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();
        
        builder.HasMany(x => x.Playlists).WithOne();
        builder.HasMany(x => x.CreditCards).WithOne();
        builder.HasOne(x => x.Subscription);
    }
}
