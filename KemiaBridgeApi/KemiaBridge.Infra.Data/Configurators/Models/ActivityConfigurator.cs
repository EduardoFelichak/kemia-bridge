using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class ActivityConfigurator : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("activity");

            builder.HasKey(a => a.ActivityId);

            builder.Property(a => a.ActivityId)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(a => a.Priority)
                .IsRequired();

            builder.Property(a => a.Status)
                .IsRequired();

            builder.HasOne<User>()
                .WithMany(u => u.Activities)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Station>()
                .WithMany(s => s.Activities)
                .HasForeignKey(a => a.StationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
