﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarea2_RegistroCompleto.DAL;

namespace Tarea2_RegistroCompleto.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Tarea2_RegistroCompleto.Entidades.DatosPersonales", b =>
                {
                    b.Property<int>("DatosPersonalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cedula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("TEXT");

                    b.Property<int>("Telefono")
                        .HasColumnType("INTEGER");

                    b.HasKey("DatosPersonalesId");

                    b.ToTable("DatosPersonales");
                });

            modelBuilder.Entity("Tarea2_RegistroCompleto.Entidades.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.Property<string>("PersonaId")
                        .HasColumnType("TEXT");

                    b.HasKey("PrestamoId");

                    b.ToTable("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
