using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class StepConfigurator : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.ToTable("step");

            builder.HasKey(s => s.StepId);

            builder.Property(s => s.StepId)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.Icon)
                .IsRequired()
                .HasMaxLength(20);
                
            builder.HasOne<Station>(s => s.Station)
                .WithMany(s => s.Steps)
                .HasForeignKey(s => s.StationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Tanks)
                .WithOne()
                .HasForeignKey(t => t.TankId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Blowers)
                .WithOne()
                .HasForeignKey(b => b.BlowerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Squeezers)
                .WithOne()
                .HasForeignKey(sq => sq.SqueezerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
