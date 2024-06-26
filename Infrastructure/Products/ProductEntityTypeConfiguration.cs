using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace logistics_management_backend.Infrastructure.Products;

public class ProductEntityTypeConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", SchemaNames.LM);
        builder.HasKey(prod => prod.Id);
        builder.HasOne<ProductPosition>(prod => prod.position);
        
    }
}