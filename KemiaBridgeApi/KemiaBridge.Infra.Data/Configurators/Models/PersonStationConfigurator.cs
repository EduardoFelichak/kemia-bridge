using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class PersonStationConfigurator : IEntityTypeConfiguration<PersonStation>
    {
        public void Configure(EntityTypeBuilder<PersonStation> builder)
        {
            builder.ToTable("person_station");

            builder.HasKey(ps => new { ps.PersonId, ps.StationId });

            builder.HasOne(ps => ps.Person)
                   .WithMany(p => p.PersonStations)
                   .HasForeignKey(ps => ps.PersonId);

            builder.HasOne(ps => ps.Station)
                   .WithMany(s => s.PersonStations)
                   .HasForeignKey(ps => ps.StationId);
        }
    }
}
