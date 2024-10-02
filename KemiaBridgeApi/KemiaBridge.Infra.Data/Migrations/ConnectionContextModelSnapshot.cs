﻿// <auto-generated />
using System;
using KemiaBridge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KemiaBridge.Infra.Data.Migrations
{
    [DbContext(typeof(ConnectionContext))]
    partial class ConnectionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("AddressId");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Blower", b =>
                {
                    b.Property<int>("BlowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("StepId")
                        .HasColumnType("integer");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("BlowerId");

                    b.ToTable("blower", (string)null);
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PersonId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("PersonId");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("person", (string)null);
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.PersonStation", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<int>("StationId")
                        .HasColumnType("integer");

                    b.HasKey("PersonId", "StationId");

                    b.HasIndex("StationId");

                    b.ToTable("person_station", (string)null);
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Squeezer", b =>
                {
                    b.Property<int>("SqueezerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SqueezerId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StepId")
                        .HasColumnType("integer");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SqueezerId");

                    b.ToTable("squeezer");
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StationId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("StationId");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("station", (string)null);
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Step", b =>
                {
                    b.Property<int>("StepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StepId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("StationId")
                        .HasColumnType("integer");

                    b.HasKey("StepId");

                    b.HasIndex("StationId");

                    b.ToTable("step", (string)null);
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Tank", b =>
                {
                    b.Property<int>("TankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TankId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("StepId")
                        .HasColumnType("integer");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("TankId");

                    b.HasIndex("StepId");

                    b.ToTable("tank", (string)null);
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IX_User_Email");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_User_Name");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasDatabaseName("IX_User_Phone");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.LegalPerson", b =>
                {
                    b.HasBaseType("KemiaBridge.Domain.Entities.Person");

                    b.Property<string>("CorporateReason")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("FederalRegister")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.ToTable("legal_person", (string)null);
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.PhysicPerson", b =>
                {
                    b.HasBaseType("KemiaBridge.Domain.Entities.Person");

                    b.Property<DateTime>("BornAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("RegisterCode")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<string>("SocialName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.ToTable("physic_person", (string)null);
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Blower", b =>
                {
                    b.HasOne("KemiaBridge.Domain.Entities.Step", null)
                        .WithMany("Blowers")
                        .HasForeignKey("BlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Person", b =>
                {
                    b.HasOne("KemiaBridge.Domain.Entities.Address", null)
                        .WithOne()
                        .HasForeignKey("KemiaBridge.Domain.Entities.Person", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.PersonStation", b =>
                {
                    b.HasOne("KemiaBridge.Domain.Entities.Person", "Person")
                        .WithMany("PersonStations")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KemiaBridge.Domain.Entities.Station", "Station")
                        .WithMany("PersonStations")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Station", b =>
                {
                    b.HasOne("KemiaBridge.Domain.Entities.Address", null)
                        .WithOne()
                        .HasForeignKey("KemiaBridge.Domain.Entities.Station", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Step", b =>
                {
                    b.HasOne("KemiaBridge.Domain.Entities.Station", null)
                        .WithMany("Steps")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Tank", b =>
                {
                    b.HasOne("KemiaBridge.Domain.Entities.Step", null)
                        .WithMany("Tanks")
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.LegalPerson", b =>
                {
                    b.HasOne("KemiaBridge.Domain.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("KemiaBridge.Domain.Entities.LegalPerson", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.PhysicPerson", b =>
                {
                    b.HasOne("KemiaBridge.Domain.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("KemiaBridge.Domain.Entities.PhysicPerson", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Person", b =>
                {
                    b.Navigation("PersonStations");
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Station", b =>
                {
                    b.Navigation("PersonStations");

                    b.Navigation("Steps");
                });

            modelBuilder.Entity("KemiaBridge.Domain.Entities.Step", b =>
                {
                    b.Navigation("Blowers");

                    b.Navigation("Tanks");
                });
#pragma warning restore 612, 618
        }
    }
}
