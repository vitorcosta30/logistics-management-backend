using logistics_management_backend.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace logistics_management_backend.Infrastructure.Requests;

public class RequestHistoryItemEntityTypeConfiguration : IEntityTypeConfiguration<RequestHistoryItem>
{
    public void Configure(EntityTypeBuilder<RequestHistoryItem> builder)
    {
        builder.ToTable("RequestHistoryItem", SchemaNames.LM);
        builder.Property(reqHistoryItem => reqHistoryItem.status);
    }
}