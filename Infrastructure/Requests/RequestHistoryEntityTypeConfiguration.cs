using logistics_management_backend.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace logistics_management_backend.Infrastructure.Requests;

public class RequestHistoryEntityTypeConfiguration : IEntityTypeConfiguration<RequestHistory>
{
    public void Configure(EntityTypeBuilder<RequestHistory> builder)
    {
        builder.ToTable("RequestHistory", SchemaNames.LM);
        builder.HasOne<RequestHistoryItem>(reqHistory => reqHistory.currentStatus);

        builder.HasMany<RequestHistoryItem>(reqHistory => reqHistory.previousStatus);
        
    }
}