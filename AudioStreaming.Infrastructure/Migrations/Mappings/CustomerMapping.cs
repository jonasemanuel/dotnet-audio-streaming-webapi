using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AudioStreaming.Infrastructure;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));

        ValueConverter emailConverter = new ValueConverter<Email, string>(
            v => v.Value,
            v => new Email(v)
        );
        
        ValueConverter passwordConverter = new ValueConverter<Password, string>(
            v => v.Value,
            v => new Password(v)
        );

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Gender).IsRequired();
        builder.Property(x => x.BornDate).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.Email).HasConversion(emailConverter).HasColumnName("Email").IsRequired();
        builder.Property(x => x.Password).HasConversion(passwordConverter).HasColumnName("Password").IsRequired();
        
        builder.HasMany(x => x.Playlists).WithOne();
        builder.HasMany(x => x.CreditCards).WithOne();
        builder.HasOne(x => x.Subscription);
    }
}
