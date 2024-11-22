using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class SensorReadingConfigurator : IEntityTypeConfiguration<SensorReading>
    {
        public void Configure(EntityTypeBuilder<SensorReading> builder)
        {
            builder.ToTable("sensor_reading");

            builder.HasKey(s => s.SensorReadingId);

            builder.Property(s => s.SensorReadingId)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.ReadingDate)
                .IsRequired();

            builder.Property(s => s.Data)
                .IsRequired();

            builder.HasOne<Sensor>()
                .WithMany(S => S.SensorReadings)
                .HasForeignKey(s => s.SensorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<User>()
                .WithMany(S => S.SensorReadings)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
