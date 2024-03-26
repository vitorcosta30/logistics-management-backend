using logistics_management_backend.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace logistics_management_backend.Infrastructure.Requests;

public class RequestListEntityTypeConfiguration : IEntityTypeConfiguration<RequestItemList>
{
    public void Configure(EntityTypeBuilder<RequestItemList> builder)
    {
        builder.ToTable("RequestItemList", SchemaNames.LM);
        builder.HasMany<RequestItem>(reqItemList => reqItemList.items);
    }
}