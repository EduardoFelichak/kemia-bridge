﻿using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KemiaBridge.Infra.Data.Configurators.Models
{
    public class PhysicPersonConfigurator : IEntityTypeConfiguration<PhysicPerson>
    {
        public void Configure(EntityTypeBuilder<PhysicPerson> builder)
        {
            builder.ToTable("physic_person");

            builder.HasOne<Person>()
                   .WithOne()
                   .HasForeignKey<PhysicPerson>(pp => pp.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(pp => pp.RegisterCode)
                   .IsRequired()
                   .HasMaxLength(14);

            builder.Property(pp => pp.SocialName)
                   .HasMaxLength(100);

            builder.Property(pp => pp.BornAt)
                   .IsRequired();

            builder.Property(pp => pp.Gender)
                   .IsRequired();
        }
    }
}
