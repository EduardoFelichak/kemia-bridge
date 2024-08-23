using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class BlowerConfigurator : IEntityTypeConfiguration<Blower>
    {
        public void Configure(EntityTypeBuilder<Blower> builder)
        {
            builder.ToTable("blower");

            builder.HasKey(b => b.BlowerId);

            builder.Property(b => b.BlowerId)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Tag)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne<Step>()
                .WithMany(s => s.Blowers)
                .HasForeignKey(b => b.BlowerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
