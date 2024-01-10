﻿// <auto-generated />
using System;
using AdministracionMasVidaDbContext.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdministracionMasVida.Migrations
{
    [DbContext(typeof(AdministracionMasVidaDbcontext))]
    [Migration("20240110224123_masvida2")]
    partial class masvida2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AdministracionMasVida.Entities.EventosMv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("GpId")
                        .HasColumnType("int");

                    b.Property<int?>("LugarId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GpId");

                    b.HasIndex("LugarId");

                    b.ToTable("EventosMv");
                });

            modelBuilder.Entity("AdministracionMasVida.Entities.LugaresMv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LugaresMv");
                });

            modelBuilder.Entity("AdministracionMasVidaDbContext.Entities.GrupoPequeno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Dia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HoraFin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HoraInicio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("MentorId")
                        .HasColumnType("int");

                    b.Property<string>("NombreGrupo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.ToTable("GrupoPequeno");
                });

            modelBuilder.Entity("AdministracionMasVidaDbContext.Entities.Miembro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("grupoPequenosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("grupoPequenosId");

                    b.ToTable("Miembro");
                });

            modelBuilder.Entity("AdministracionMasVidaDbContext.Entities.Servidor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LiderGrupoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LiderGrupoId");

                    b.ToTable("Servidor");
                });

            modelBuilder.Entity("AdministracionMasVida.Entities.EventosMv", b =>
                {
                    b.HasOne("AdministracionMasVidaDbContext.Entities.GrupoPequeno", "Gp")
                        .WithMany("eventosMv")
                        .HasForeignKey("GpId");

                    b.HasOne("AdministracionMasVida.Entities.LugaresMv", "Lugar")
                        .WithMany("Evento")
                        .HasForeignKey("LugarId");

                    b.Navigation("Gp");

                    b.Navigation("Lugar");
                });

            modelBuilder.Entity("AdministracionMasVidaDbContext.Entities.GrupoPequeno", b =>
                {
                    b.HasOne("AdministracionMasVidaDbContext.Entities.Servidor", "Mentor")
                        .WithMany("MentorGrupos")
                        .HasForeignKey("MentorId");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("AdministracionMasVidaDbContext.Entities.Miembro", b =>
                {
                    b.HasOne("AdministracionMasVidaDbContext.Entities.GrupoPequeno", "grupoPequenos")
                        .WithMany("Miembro")
                        .HasForeignKey("grupoPequenosId");

                    b.Navigation("grupoPequenos");
                });

            modelBuilder.Entity("AdministracionMasVidaDbContext.Entities.Servidor", b =>
                {
                    b.HasOne("AdministracionMasVidaDbContext.Entities.GrupoPequeno", "LiderGrupo")
                        .WithMany("Lideres")
                        .HasForeignKey("LiderGrupoId");

                    b.Navigation("LiderGrupo");
                });

            modelBuilder.Entity("AdministracionMasVida.Entities.LugaresMv", b =>
                {
                    b.Navigation("Evento");
                });

            modelBuilder.Entity("AdministracionMasVidaDbContext.Entities.GrupoPequeno", b =>
                {
                    b.Navigation("Lideres");

                    b.Navigation("Miembro");

                    b.Navigation("eventosMv");
                });

            modelBuilder.Entity("AdministracionMasVidaDbContext.Entities.Servidor", b =>
                {
                    b.Navigation("MentorGrupos");
                });
#pragma warning restore 612, 618
        }
    }
}