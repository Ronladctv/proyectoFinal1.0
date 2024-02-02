using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoFinal.Models;
using proyectoFinal.Models.Entidades;
using proyectoFinal.Services;

namespace proyectoFinal.Controllers
{
    [Authorize(Policy = "RequireLoggedIn")]

    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private readonly SMedicoContext _context;

        private readonly IServicioUsuarios _servicioUsuario;
        private readonly IServicioImagen _servicioImagen;

        public UsuariosController(IServicioUsuarios servicioUsuario,
         IServicioImagen servicioImagen, SMedicoContext context)
        {
            _servicioUsuario = servicioUsuario;
            _servicioImagen = servicioImagen;
            _context = context;
        }

        public async Task<IActionResult> ListadoUsuario()
        {
            //  _context.Usuarios
            return View(await _context.Usuarios.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

    
        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> Editar(Usuarios usuario, IFormFile Imagen)
        {
            try
            {
                var usuarioexistente = await _context.Usuarios.FindAsync(usuario.UsuarioID);
                if (usuarioexistente != null)
                {
                    if (Imagen != null)
                    {
                        Stream image = Imagen.OpenReadStream();
                        usuarioexistente.URLFotoPerfil = await _servicioImagen.SubirImagen(image, Imagen.FileName);
                    }

                    usuarioexistente.Nombre = usuario.Nombre;
                    usuarioexistente.Apellido = usuario.Apellido;
                    usuarioexistente.correo = usuario.correo;
                    usuarioexistente.Clave = Utilitarios.EncriptarClave(usuario.Clave);
                    usuarioexistente.URLFotoPerfil = usuario.URLFotoPerfil;
                    usuarioexistente.Roles = usuario.Roles;

                    _context.Entry(usuarioexistente).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    TempData["AlertMessage"] = "Usuario actualizado exitosamente!!!";
                    return RedirectToAction("ListadoUsuario");
                }
                else
                {
                    return NotFound(); // Manejar el caso donde el usuario no se encuentra
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrió un error al actualizar");
            }

            return View(usuario);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioID == id);

            if (usuario == null)
            {
                return NotFound();
            }

            try
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Usuario eliminado exitosamente!!!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrió un error, no se pudo eliminar el registro");
            }

            return RedirectToAction(nameof(ListadoUsuario));
        }





    }

}