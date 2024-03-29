﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyectoFinal.Models;

#nullable disable

namespace proyectoFinal.Migrations
{
    [DbContext(typeof(SMedicoContext))]
    [Migration("20240130015748_Base_citas")]
    partial class Base_citas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("proyectoFinal.Models.Entidades.CitasMedicas", b =>
                {
                    b.Property<int>("CitaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CitaID"));

                    b.Property<int>("Doctorid")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duracion")
                        .HasColumnType("time");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHoraCita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("TipoConsulta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CitaID");

                    b.HasIndex("Doctorid");

                    b.HasIndex("PacienteId");

                    b.ToTable("CitasMedicas");
                });

            modelBuilder.Entity("proyectoFinal.Models.Entidades.Doctores", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorID"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Especialidadid")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("DoctorID");

                    b.HasIndex("Especialidadid");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Doctores");
                });

            modelBuilder.Entity("proyectoFinal.Models.Entidades.Especialidad", b =>
                {
                    b.Property<int>("EspecialidadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EspecialidadID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NombreEspecialidad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EspecialidadID");

                    b.ToTable("Especialidad");
                });

            modelBuilder.Entity("proyectoFinal.Models.Entidades.HistorialMedico", b =>
                {
                    b.Property<int>("HistorialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistorialID"));

                    b.Property<string>("Alergias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AntecedentesFamiliares")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AntecedentesPersonales")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Medicamentoid")
                        .HasColumnType("int");

                    b.Property<string>("NotasObservaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumHistorial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pacienteid")
                        .HasColumnType("int");

                    b.HasKey("HistorialID");

                    b.HasIndex("Medicamentoid");

                    b.HasIndex("Pacienteid");

                    b.ToTable("HistorialMedico");
                });

            modelBuilder.Entity("proyectoFinal.Models.Entidades.Medicamento", b =>
                {
                    b.Property<int>("MedicamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicamentoID"));

                    b.Property<string>("Concentracion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormFarmaceutica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMedicamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicamentoID");

                    b.ToTable("Medicamento");
                });

            modelBuilder.Entity("proyectoFinal.Models.Entidades.Pacientes", b =>
                {
                    b.Property<int>("PacienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacienteID"));

                    b.Property<string>("ApellidoPaciente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("NombrePaciente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PacienteID");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("proyectoFinal.Models.Entidades.Roles", b =>
                {
                    b.Property<int>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolID"));

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("proyectoFinal.Models.Entidades.Usuarios", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioID"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLFotoPerfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("proyectoFinal.Models.Entidades.CitasMedicas", b =>
                {
                    b.HasOne("proyectoFinal.Models.Entidades.Doctores", "Doctores")
                        .WithMany()
                        .HasForeignKey("Doctorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proyectoFinal.Models.Entidades.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctores");

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("proyectoFinal.Models.Entidades.Doctores", b =>
                {
                    b.HasOne("proyectoFinal.Models.Entidades.Especialidad", "Especialidades")
                        .WithMany()
                        .HasForeignKey("Especialidadid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proyectoFinal.Models.Entidades.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidades");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("proyectoFinal.Models.Entidades.HistorialMedico", b =>
                {
                    b.HasOne("proyectoFinal.Models.Entidades.Medicamento", "Medicamento")
                        .WithMany()
                        .HasForeignKey("Medicamentoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proyectoFinal.Models.Entidades.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("Pacienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
