using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class StationConfigurator : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.ToTable("station");

            builder.HasKey(s => s.StationId);

            builder.Property(s => s.StationId)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.OperationDate)
                .IsRequired();

            builder.HasOne<Address>()
                .WithOne()
                .HasForeignKey<Station>(s => s.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Steps)
                .WithOne(s => s.Station)
                .HasForeignKey(s => s.StationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Activities)
                .WithOne()
                .HasForeignKey(s => s.StationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
