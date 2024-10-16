using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class UserConfigurator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserId)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Type)
                .IsRequired();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Phone)
                .HasMaxLength(15);

            builder.HasIndex(u => u.Name)
                .IsUnique()
                .HasDatabaseName("IX_User_Name");

            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("IX_User_Email");

            builder.HasIndex(u => u.Phone)
                .IsUnique()
                .HasDatabaseName("IX_User_Phone");

            builder.HasMany(u => u.Activities)
                .WithOne()
                .HasForeignKey(a => a.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
