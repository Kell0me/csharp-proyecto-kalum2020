﻿// <auto-generated />
using System;
using Kalum2020v1.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kalum2020v1.Migrations
{
    [DbContext(typeof(KalumDbContext))]
    [Migration("20200425145906_ModifyTableName")]
    partial class ModifyTableName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kalum2020v1.Models.Alumno", b =>
                {
                    b.Property<int>("AlumnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Carne")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReligionId")
                        .HasColumnType("int");

                    b.HasKey("AlumnoId");

                    b.HasIndex("ReligionId");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("Kalum2020v1.Models.AsignacionAlumno", b =>
                {
                    b.Property<int>("AsignacionAlumnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlumnoID")
                        .HasColumnType("int");

                    b.Property<int>("AsAlumnoID")
                        .HasColumnType("int");

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAsignacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AsignacionAlumnoId");

                    b.HasIndex("AlumnoID");

                    b.HasIndex("ClaseId");

                    b.ToTable("AsignacionAlumnos");
                });

            modelBuilder.Entity("Kalum2020v1.Models.CarreraTecnica", b =>
                {
                    b.Property<int>("CarreraTecnicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreCarrera")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarreraTecnicaId");

                    b.ToTable("CarreraTecnica");
                });

            modelBuilder.Entity("Kalum2020v1.Models.Clase", b =>
                {
                    b.Property<int>("ClaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadAsignaciones")
                        .HasColumnType("int");

                    b.Property<string>("CarreraId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarreraTecnicaId")
                        .HasColumnType("int");

                    b.Property<int>("Ciclo")
                        .HasColumnType("int");

                    b.Property<int>("CupoMaximo")
                        .HasColumnType("int");

                    b.Property<int>("CupoMinimo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HorarioID")
                        .HasColumnType("int");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("IsntructorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("ClaseID");

                    b.HasIndex("CarreraTecnicaId");

                    b.HasIndex("HorarioID");

                    b.HasIndex("InstructorId");

                    b.HasIndex("SalonID");

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("Kalum2020v1.Models.Horario", b =>
                {
                    b.Property<int>("HorarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HorarioFinal")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HorarioId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("HorarioId");

                    b.HasIndex("HorarioId1");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("Kalum2020v1.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InstructorId1")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.HasIndex("InstructorId1");

                    b.ToTable("Instructores");
                });

            modelBuilder.Entity("Kalum2020v1.Models.Religion", b =>
                {
                    b.Property<int>("ReligionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReligionId");

                    b.ToTable("Religion");
                });

            modelBuilder.Entity("Kalum2020v1.Models.Salon", b =>
                {
                    b.Property<int>("SalonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreSalon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalonId1")
                        .HasColumnType("int");

                    b.HasKey("SalonId");

                    b.HasIndex("SalonId1");

                    b.ToTable("Salones");
                });

            modelBuilder.Entity("Kalum2020v1.Models.Alumno", b =>
                {
                    b.HasOne("Kalum2020v1.Models.Religion", "Religion")
                        .WithMany("Alumnos")
                        .HasForeignKey("ReligionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kalum2020v1.Models.AsignacionAlumno", b =>
                {
                    b.HasOne("Kalum2020v1.Models.Alumno", "Alumno")
                        .WithMany("AsignacionAlumnos")
                        .HasForeignKey("AlumnoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kalum2020v1.Models.Clase", "Clase")
                        .WithMany("AsignacionAlumnos")
                        .HasForeignKey("ClaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kalum2020v1.Models.Clase", b =>
                {
                    b.HasOne("Kalum2020v1.Models.CarreraTecnica", "CarreraTecnica")
                        .WithMany("Clases")
                        .HasForeignKey("CarreraTecnicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kalum2020v1.Models.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("HorarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kalum2020v1.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId");

                    b.HasOne("Kalum2020v1.Models.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kalum2020v1.Models.Horario", b =>
                {
                    b.HasOne("Kalum2020v1.Models.Horario", null)
                        .WithMany("Horarios")
                        .HasForeignKey("HorarioId1");
                });

            modelBuilder.Entity("Kalum2020v1.Models.Instructor", b =>
                {
                    b.HasOne("Kalum2020v1.Models.Instructor", null)
                        .WithMany("Instructores")
                        .HasForeignKey("InstructorId1");
                });

            modelBuilder.Entity("Kalum2020v1.Models.Salon", b =>
                {
                    b.HasOne("Kalum2020v1.Models.Salon", null)
                        .WithMany("Salones")
                        .HasForeignKey("SalonId1");
                });
#pragma warning restore 612, 618
        }
    }
}
