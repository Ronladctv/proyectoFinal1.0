using proyectoFinal.Models.Entidades;
using proyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace proyectoFinal.Services
{
    public class ServicioRoles : IServicioRoles
    {

        private readonly SMedicoContext _context; //informacion de la libreria context de entidades

        public ServicioRoles(SMedicoContext context)
        {
            _context = context;
        }

        public async Task<Roles> SaveRoles(Roles roles)
        {

            _context.Roles.Add(roles);
            await _context.SaveChangesAsync();
            return roles;

        }

        public async Task<Roles> Get(string NombreRol)
        {
            return await _context.Roles.FirstOrDefaultAsync(c => c.NombreRol == NombreRol);
        }

    }
}