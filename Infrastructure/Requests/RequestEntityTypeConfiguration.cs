using logistics_management_backend.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace logistics_management_backend.Infrastructure.Requests;

public class RequestEntityTypeConfiguration: IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests", SchemaNames.LM);
        builder.HasOne<RequestHistory>(req => req.status);
        builder.HasOne<RequestItemList>(req => req.listOfItems);

    }
}