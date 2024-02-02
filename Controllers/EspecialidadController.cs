using Microsoft.AspNetCore.Mvc;
using proyectoFinal.Models.Entidades;
using proyectoFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace proyectoFinal.Controllers
{
    [Authorize(Policy = "RequireLoggedIn")]
    [Authorize(Roles = "Admin,Doctor")]
    public class EspecialidadController : Controller
    {
        private readonly SMedicoContext _context;

        public EspecialidadController(SMedicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListadoEspecialidad()
        {
            return View(await _context.Especialidad.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Especialidad especialidad)
        {

            if (ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "especialidad creada exitosamente";
                return RedirectToAction("ListadoEspecialidad");

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido Un error");
            }



            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Especialidad == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Especialidad especialidad)
        {
            if (id != especialidad.EspecialidadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidad);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Especialidad actualizado " +
                        "exitosamente!!!";
                    return RedirectToAction("ListadoEspecialidad");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error " +
                        "al actualizar");
                }
            }
            return View(especialidad);
        }


        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Especialidad == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad
                .FirstOrDefaultAsync(m => m.EspecialidadID == id);

            if (especialidad == null)
            {
                return NotFound();
            }

            try
            {
                _context.Especialidad.Remove(especialidad);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "especialidad eliminado exitosamente!!!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }

            return RedirectToAction(nameof(ListadoEspecialidad));
        }
        public IActionResult Index()
        {
            return View();
        }









    }
}