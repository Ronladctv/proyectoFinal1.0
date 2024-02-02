using proyectoFinal.Models.Entidades;
using proyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace proyectoFinal.Services
{
    public class ServicioEspecialidad : IServicioEspecialidad

    {

        private readonly SMedicoContext _context; //informacion de la libreria context de entidades

        public ServicioEspecialidad(SMedicoContext context)
        {
            _context = context;
        }

        public async Task<Especialidad> GetEspecialidad(string NombreEspecialidad)
        {
            return await _context.Especialidad.FirstOrDefaultAsync(c => c.NombreEspecialidad == NombreEspecialidad);
        }

        public async Task<Especialidad> SaveEspecialidad(Especialidad especialidad)
        {
            _context.Especialidad.Add(especialidad);
            await _context.SaveChangesAsync();
            return especialidad;
        }
    }
}