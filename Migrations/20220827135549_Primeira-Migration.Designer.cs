﻿// <auto-generated />
using System;
using Consultorio.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Consultorio.Migrations
{
    [DbContext(typeof(ConsultorioContext))]
    [Migration("20220827135549_Primeira-Migration")]
    partial class PrimeiraMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Consultorio.Models.Entities.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataHorario")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_horario");

                    b.Property<int>("EspecialidadeId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("id_profissional");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int")
                        .HasColumnName("id_paciente");

                    b.Property<decimal>("Preco")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)")
                        .HasColumnName("preco");

                    b.Property<int>("ProfissionalId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("id_profissional");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadeId");

                    b.HasIndex("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Consultorio.Models.Entities.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativa")
                        .HasColumnType("bit")
                        .HasColumnName("ativa");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Consultorio.Models.Entities.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("celular");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Consultorio.Models.Entities.Profissional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Profissionais");
                });

            modelBuilder.Entity("Consultorio.Models.Entities.ProfissionalEspecialidade", b =>
                {
                    b.Property<int>("EspecialidadeId")
                        .HasColumnType("int")
                        .HasColumnName("id_especialidade");

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("int")
                        .HasColumnName("id_profissional");

                    b.HasKey("EspecialidadeId", "ProfissionalId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("tb_profissional_especialidade");
                });

            modelBuilder.Entity("Consultorio.Models.Entities.Consulta", b =>
                {
                    b.HasOne("Consultorio.Models.Entities.Especialidade", "Especilidade")
                        .WithMany("Consultas")
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Consultorio.Models.Entities.Paciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Consultorio.Models.Entities.Profissional", "Profissional")
                        .WithMany("Consultas")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especilidade");

                    b.Navigation("Paciente");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("Consultorio.Models.Entities.Profissional", b =>
                {
                    b.HasOne("Consultorio.Models.Entities.Paciente", null)
                        .WithMany("Profissionais")
                        .HasForeignKey("PacienteId");
                });

            modelBuilder.Entity("Consultorio.Models.Entities.ProfissionalEspecialidade", b =>
                {
                    b.HasOne("Consultorio.Models.Entities.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Consultorio.Models.Entities.Profissional", "Profissionais")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidade");

                    b.Navigation("Profissionais");
                });

            modelBuilder.Entity("Consultorio.Models.Entities.Especialidade", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("Consultorio.Models.Entities.Paciente", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("Profissionais");
                });

            modelBuilder.Entity("Consultorio.Models.Entities.Profissional", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
