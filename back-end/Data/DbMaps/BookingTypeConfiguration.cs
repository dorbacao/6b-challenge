using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BookingTypeConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.CreatedOn).IsRequired(true);
        builder.Property(a => a.BookingDate).IsRequired(true);
        builder.Property(a => a.VehicleSize).IsRequired(true);
        builder.Property(a => a.Flexibility).IsRequired(true);
        builder.Property(a => a.ContactNumber).IsRequired(true);
    }
}