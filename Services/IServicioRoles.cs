using proyectoFinal.Models.Entidades;

namespace proyectoFinal.Services
{
    public interface IServicioRoles
    {
        Task<Roles> SaveRoles(Roles roles);

        Task<Roles> Get(string NombreRol);
    }
}
