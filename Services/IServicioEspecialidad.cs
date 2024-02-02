using proyectoFinal.Models.Entidades;

namespace proyectoFinal.Services
{
    public interface IServicioEspecialidad
    {
        Task<Especialidad> SaveEspecialidad(Especialidad especialidad);

        Task<Especialidad> GetEspecialidad(string NombreEspecialidad);
    }
}
