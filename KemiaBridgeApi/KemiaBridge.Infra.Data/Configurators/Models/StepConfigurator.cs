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
                
            builder.HasOne<Station>()
                .WithMany()
                .HasForeignKey(s => s.StationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
