using proyectoFinal.Models.Entidades;

namespace proyectoFinal.Services
{
    public interface IServicioHistorialMedico
    {
        Task<HistorialMedico> SaveHistorialMedico(HistorialMedico historialMedico);

        Task<HistorialMedico> GetHistorialMedico(string numHistorial);
    }
}
