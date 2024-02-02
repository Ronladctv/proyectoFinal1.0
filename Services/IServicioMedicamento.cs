using proyectoFinal.Models.Entidades;

namespace proyectoFinal.Services
{
    public interface IServicioMedicamento
    {

        Task<Medicamento> SaveMedicamento(Medicamento medicamento);

        Task<Medicamento> GetMedicamento(string NombreMedicamento);
    }
}
