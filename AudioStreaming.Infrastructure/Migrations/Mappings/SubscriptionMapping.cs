using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AudioStreaming.Infrastructure;

public class SubscriptionMapping : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
      builder.ToTable(nameof(Subscription));

      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.IsActive).IsRequired();
      builder.Property(x => x.CreatedAt).IsRequired();

      builder.HasOne(x => x.Plan).WithMany();
    }
}
