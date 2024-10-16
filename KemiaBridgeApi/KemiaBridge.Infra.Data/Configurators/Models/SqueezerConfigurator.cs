using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class SqueezerConfigurator : IEntityTypeConfiguration<Squeezer>
    {
        public void Configure(EntityTypeBuilder<Squeezer> builder)
        {
            builder.ToTable("squeezer");

            builder.HasKey(s => s.SqueezerId);

            builder.Property(s => s.SqueezerId)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Tag)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne<Step>()
                .WithMany(st => st.Squeezers)
                .HasForeignKey(s => s.StepId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
