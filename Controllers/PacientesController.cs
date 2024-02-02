using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoFinal.Models;
using proyectoFinal.Models.Entidades;

namespace proyectoFinal.Controllers
{
    [Authorize(Policy = "RequireLoggedIn")]
    [Authorize(Roles = "Admin,Doctor,Usuario")]
    public class PacientesController : Controller
    {
        private readonly SMedicoContext _context;

        public PacientesController(SMedicoContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> ListadoPacientes()
        {
            return View(await _context.Pacientes.ToListAsync());
        }

        

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Pacientes pacientes)
        {

            if (ModelState.IsValid)
            {
                _context.Add(pacientes);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "paciente creado exitosamente";
                return RedirectToAction("ListadoPacientes");

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
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes.FindAsync(id);
            if (pacientes == null)
            {
                return NotFound();
            }
            return View(pacientes);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Pacientes pacientes)
        {
            if (id != pacientes.PacienteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacientes);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Paciente actualizado " +
                        "exitosamente!!!";
                    return RedirectToAction("ListadoPacientes");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error " +
                        "al actualizar");
                }
            }
            return View(pacientes);
        }


        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var pacientes = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.PacienteID == id);

            if (pacientes == null)
            {
                return NotFound();
            }

            try
            {
                _context.Pacientes.Remove(pacientes);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "paciente eliminado exitosamente!!!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }

            return RedirectToAction(nameof(ListadoPacientes));
        }
        public IActionResult Index()
        {
            return View();
        }









    }
}