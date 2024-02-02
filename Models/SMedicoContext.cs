using Microsoft.EntityFrameworkCore;
using proyectoFinal.Models.Entidades;

namespace proyectoFinal.Models
{
    public class SMedicoContext : DbContext
    {

        public SMedicoContext()
        {

        }

        public SMedicoContext(DbContextOptions<SMedicoContext> options) : base(options) { }
        public DbSet<CitasMedicas> CitasMedicas { get; set; }
        public DbSet<Doctores> Doctores { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }

        public DbSet<HistorialMedico> HistorialMedico { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Pacientes> Pacientes { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)  //Este metodo q va ayudar a conectar con la BDD
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}

