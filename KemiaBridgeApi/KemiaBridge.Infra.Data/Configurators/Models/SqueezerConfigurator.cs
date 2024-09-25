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
        }
    }
}
