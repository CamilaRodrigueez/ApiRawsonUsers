﻿// <auto-generated />
using System;
using Infraestructure.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Infraestructure.Entity.Models.ContactoPersonaEntity", b =>
                {
                    b.Property<int>("IdContacto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContacto"), 1L, 1);

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoContacto")
                        .HasColumnType("int");

                    b.HasKey("IdContacto");

                    b.HasIndex("IdPersona");

                    b.HasIndex("IdTipoContacto", "IdPersona")
                        .IsUnique();

                    b.ToTable("ContactoPersona");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PersonaEntity", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersona"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPersona");

                    b.HasIndex("Identificacion")
                        .IsUnique()
                        .HasDatabaseName("Index_Identificacion");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.TipoContactoEntity", b =>
                {
                    b.Property<int>("IdTipoContacto")
                        .HasColumnType("int");

                    b.Property<string>("TipoContacto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTipoContacto");

                    b.ToTable("TipoContacto");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ContactoPersonaEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.PersonaEntity", "PersonaEntity")
                        .WithMany()
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.TipoContactoEntity", "TipoContactoEntity")
                        .WithMany()
                        .HasForeignKey("IdTipoContacto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonaEntity");

                    b.Navigation("TipoContactoEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
