using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class AddressConfigurator : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

            builder.HasKey(a => a.AddressId);

            builder.Property(a => a.AddressId)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.ZipCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Complement)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(2);
        }
    }
}
