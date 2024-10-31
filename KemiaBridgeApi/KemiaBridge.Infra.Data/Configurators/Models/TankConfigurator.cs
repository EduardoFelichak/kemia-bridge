using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class TankConfigurator : IEntityTypeConfiguration<Tank>
    {
        public void Configure(EntityTypeBuilder<Tank> builder)
        {
            builder.ToTable("tank");

            builder.HasKey(t => t.TankId);

            builder.Property(t => t.TankId)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Type)
                .IsRequired();

            builder.Property(t => t.Tag)
                .IsRequired()
                .HasMaxLength(15);  

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne<Step>()
                .WithMany(s => s.Tanks)
                .HasForeignKey(t => t.StepId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
