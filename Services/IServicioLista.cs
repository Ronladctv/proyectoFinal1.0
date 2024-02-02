using Microsoft.AspNetCore.Mvc.Rendering;

namespace proyectoFinal.Services
{
    public interface IServicioLista
    {

        Task<IEnumerable<SelectListItem>>
   GetListaEspecialidades();

        Task<IEnumerable<SelectListItem>>
            GetListaMedicamentos();

        Task<IEnumerable<SelectListItem>>
         GetListaRoles();


        Task<IEnumerable<SelectListItem>>
         GetListaUsuario();

        Task<IEnumerable<SelectListItem>>
         GetListaCitasMedicas();

        Task<IEnumerable<SelectListItem>>
        GetListaPaciente();


        Task<IEnumerable<SelectListItem>>
        GetHistorialMedico();

        Task<IEnumerable<SelectListItem>>
        GetListaDoctores();
    }
}
