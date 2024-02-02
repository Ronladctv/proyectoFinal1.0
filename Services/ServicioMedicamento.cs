using Microsoft.EntityFrameworkCore;
using proyectoFinal.Models;
using proyectoFinal.Models.Entidades;

namespace proyectoFinal.Services
{
    public class ServicioMedicamento : IServicioMedicamento
    {

        private readonly SMedicoContext _context; //informacion de la libreria context de entidades

        public ServicioMedicamento(SMedicoContext context)
        {
            _context = context;
        }
        public async Task<Medicamento> GetMedicamento(string NombreMedicamento)
        {
            return await _context.Medicamento.FirstOrDefaultAsync(c => c.NombreMedicamento == NombreMedicamento);
        }

        public async Task<Medicamento> SaveMedicamento(Medicamento medicamento)
        {
            _context.Medicamento.Add(medicamento);
            await _context.SaveChangesAsync();
            return medicamento;
        }
    }
}
