using EfCoreIssue30203.Domain.Portfolios.ValueObjects;
using EfCoreIssue30203.Domain.Products;
using EfCoreIssue30203.Domain.Products.Entities;
using EfCoreIssue30203.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreIssue30203.Persistence.Configurations;

internal sealed class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureProductsTable(builder);
        ConfigureProductCoveragesTable(builder);
    }

    private static void ConfigureProductsTable(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value));

        builder.Property(p => p.Identifier)
            .IsRequired()
            .HasMaxLength(ProductIdentifier.MaxLength)
            .HasConversion(
                identifier => identifier.Value,
                value => ProductIdentifier.Create(value));

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(ProductName.MaxLength)
            .HasConversion(
                name => name.Value,
                value => ProductName.Create(value));

        builder.OwnsOne(
            p => p.CoreSystem,
            ownedBuilder =>
            {
                ownedBuilder.Property(cs => cs.Identifier)
                    .IsRequired()
                    .HasColumnType($"CHAR({ProductCoreSystem.IdentifierLength})")
                    .HasColumnName(nameof(Product.CoreSystem));

                ownedBuilder.Property(cs => cs.Code)
                    .IsRequired()
                    .HasMaxLength(ProductCoreSystem.CodeMaxLength)
                    .HasColumnName("CoreSystemCode");
            });

        builder.Property(p => p.PortfolioId)
            .IsRequired()
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PortfolioId.Create(value));
    }

    private static void ConfigureProductCoveragesTable(EntityTypeBuilder<Product> builder)
    {
        builder.OwnsMany(
            p => p.Coverages,
            ownedBuilder =>
            {
                ownedBuilder.ToTable("ProductCoverages");

                ownedBuilder.WithOwner().HasForeignKey("ProductId");

                ownedBuilder.HasKey(c => c.Id);

                ownedBuilder.Property(c => c.Identifier)
                    .IsRequired()
                    .HasMaxLength(CoverageIdentifier.MaxLength)
                    .HasConversion(
                        identifier => identifier.Value,
                        value => CoverageIdentifier.Create(value));
            });
    }
}
