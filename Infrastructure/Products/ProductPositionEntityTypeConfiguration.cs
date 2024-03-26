using logistics_management_backend.Domain.Goods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace logistics_management_backend.Infrastructure.Products;

public class ProductPositionEntityTypeConfiguration : IEntityTypeConfiguration<ProductPosition>
{
    public void Configure(EntityTypeBuilder<ProductPosition> builder)
    {
        builder.ToTable("ProductPositions", SchemaNames.LM);
        builder.HasKey(pos => pos.Id);

    }
}