using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AudioStreaming.Infrastructure;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

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
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.Email).HasConversion(emailConverter).HasColumnName("Email").IsRequired();
        builder.Property(x => x.Password).HasConversion(passwordConverter).HasColumnName("Password").IsRequired();
        builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Role).IsRequired();
    }
}
