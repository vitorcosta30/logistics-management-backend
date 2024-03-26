using logistics_management_backend.Domain.Goods;
using logistics_management_backend.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace logistics_management_backend.Infrastructure.Requests;

public class RequestListItemEntityTypeConfiguration : IEntityTypeConfiguration<RequestItem>
{
    public void Configure(EntityTypeBuilder<RequestItem> builder)
    {
        builder.ToTable("RequestItem", SchemaNames.LM);
        builder.HasKey(reqItem => reqItem.Id);
        builder.HasOne<Product>(reqItem => reqItem.item);

    }
}