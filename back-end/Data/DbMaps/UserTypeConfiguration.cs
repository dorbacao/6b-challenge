using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired(true);
            builder.Property(a => a.Login).IsRequired(true);
            builder.Property(a => a.Password).IsRequired(true);
        }
}
