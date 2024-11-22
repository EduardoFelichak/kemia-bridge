using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class SensorConfigurator : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.ToTable("sensor");

            builder.HasKey(s => s.SensorId);

            builder.Property(s => s.SensorId)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Type)
                .IsRequired();

            builder.Property(s => s.Tag)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(s => s.Status)
                .IsRequired();

            builder.HasOne<Step>()
                .WithMany(s => s.Sensors)
                .HasForeignKey(s => s.StepId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
