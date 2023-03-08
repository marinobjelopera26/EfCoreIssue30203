using EfCoreIssue30203.Domain.Portfolios;
using EfCoreIssue30203.Domain.Portfolios.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreIssue30203.Persistence.Configurations;

internal sealed class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        ConfigurePortfoliosTable(builder);
        ConfigurePortfolioProductIdsTable(builder);
    }

    private static void ConfigurePortfoliosTable(EntityTypeBuilder<Portfolio> builder)
    {
        builder.ToTable("Portfolios");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PortfolioId.Create(value));

        builder.Property(p => p.Identifier)
            .IsRequired()
            .HasConversion(
                identifier => identifier.Value,
                value => PortfolioIdentifier.Create(value));
    }

    private static void ConfigurePortfolioProductIdsTable(EntityTypeBuilder<Portfolio> builder)
    {
        builder.OwnsMany(
            p => p.ProductIds,
            pBuilder =>
            {
                pBuilder.ToTable("PorfolioProductIds");

                pBuilder.WithOwner().HasForeignKey("PortfolioId");

                pBuilder.HasKey("Id");

                pBuilder.Property(p => p.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductId");
            });
    }
}
