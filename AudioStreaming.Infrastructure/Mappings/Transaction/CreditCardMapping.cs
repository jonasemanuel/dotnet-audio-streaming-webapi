using AudioStreaming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AudioStreaming.Infrastructure;

public class CreditCardMapping : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.ToTable(nameof(CreditCard));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Number).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.Limit).IsRequired();

        builder.HasMany(x => x.Transactions).WithOne();
    }
}
