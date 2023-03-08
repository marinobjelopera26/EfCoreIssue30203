using EfCoreIssue30203.Domain.PriceLists;
using EfCoreIssue30203.Domain.PriceLists.ValueObjects;
using EfCoreIssue30203.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreIssue30203.Infrastructure.Persistence.Configurations;

internal class PriceListConfigurations : IEntityTypeConfiguration<PriceList>
{
    public void Configure(EntityTypeBuilder<PriceList> builder)
    {
        ConfigurePriceListsTable(builder);
    }

    private void ConfigurePriceListsTable(EntityTypeBuilder<PriceList> builder)
    {
        builder.ToTable("PriceLists");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                providerValue => PriceListId.Create(providerValue));

        builder.Property(p => p.Identifier)
            .IsRequired()
            .HasConversion(
                identifier => identifier.Value,
                providerValue => PriceListIdentifier.Create(providerValue));

        builder.Property(p => p.ProductId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                providerValue => ProductId.Create(providerValue));
    }
}
