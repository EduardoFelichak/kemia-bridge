using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class LegalPersonConfigurator : IEntityTypeConfiguration<LegalPerson>
    {
        public void Configure(EntityTypeBuilder<LegalPerson> builder)
        {
            builder.ToTable("legal_person");

            builder.HasOne<Person>()
                   .WithOne()
                   .HasForeignKey<LegalPerson>(pp => pp.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(lp => lp.FederalRegister)
                   .IsRequired()
                   .HasMaxLength(18);

            builder.Property(lp => lp.CorporateReason)
                   .IsRequired()
                   .HasMaxLength(150);
        }
    }
}
