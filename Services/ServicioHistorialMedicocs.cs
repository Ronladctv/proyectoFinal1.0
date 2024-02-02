using proyectoFinal.Models.Entidades;
using proyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace proyectoFinal.Services
{
    public class ServicioHistorialMedico : IServicioHistorialMedico
    {

        private readonly SMedicoContext _context; //informacion del Sistema Medico context de entidades

        public ServicioHistorialMedico(SMedicoContext context)
        {
            _context = context;
        }
        public async Task<HistorialMedico> GetHistorialMedico(string numHistorial)
        {
            return await _context.HistorialMedico.FirstOrDefaultAsync(c => c.NumHistorial == numHistorial);
        }

        public async Task<HistorialMedico> SaveHistorialMedico(HistorialMedico historialmedico)
        {
            _context.HistorialMedico.Add(historialmedico);
            await _context.SaveChangesAsync();
            return historialmedico;
        }
    }
}