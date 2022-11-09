using Consultorio.Configuration;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Context
{
    public class ConsultorioContext : DbContext
    {
        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
        { 
           
        }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Especialidade> Especialidades { get; set;}
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Profissional> Profissionais {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Consulta>(new ConsultaConfiguration());
            modelBuilder.ApplyConfiguration<Especialidade>(new EspecialidadeConfiguration());
            modelBuilder.ApplyConfiguration<Paciente>(new PacienteConfiguration());
            modelBuilder.ApplyConfiguration<Profissional>(new ProfissionalConfiguration());
        }

    
    }
}
