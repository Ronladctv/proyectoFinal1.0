using proyectoFinal.Models.Entidades;

namespace proyectoFinal.Services
{
    public interface IServicioPacientes
    {

        Task<Pacientes> SavePacientes(Pacientes pacientes);

        Task<Pacientes> GetPacientes(string nombrePaciente);
    }
}
