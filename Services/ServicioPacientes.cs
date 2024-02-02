using Microsoft.EntityFrameworkCore;
using proyectoFinal.Models;
using proyectoFinal.Models.Entidades;

namespace proyectoFinal.Services
{
    public class ServicioPacientes : IServicioPacientes
    {

        private readonly SMedicoContext _context; //informacion de la libreria context de entidades

        public ServicioPacientes(SMedicoContext context)
        {
            _context = context;
        }

        public async Task<Pacientes> GetPacientes(string nombrePaciente)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(c => c.NombrePaciente == nombrePaciente);
        }

        public async Task<Pacientes> SavePacientes(Pacientes pacientes)
        {
            _context.Pacientes.Add(pacientes);
            await _context.SaveChangesAsync();
            return pacientes;
        }
    }
}
