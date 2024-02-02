using Microsoft.AspNetCore.Mvc;
using proyectoFinal.Models.Entidades;
using proyectoFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace proyectoFinal.Controllers
{
    [Authorize(Policy = "RequireLoggedIn")]
    [Authorize(Roles = "Admin")]
    public class MedicamentoController : Controller
    {
        private readonly SMedicoContext _context;

        public MedicamentoController(SMedicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListadoMedicamento()
        {
            return View(await _context.Medicamento.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Medicamento medicamento)
        {

            if (ModelState.IsValid)
            {
                _context.Add(medicamento);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "medicamento creado exitosamente";
                return RedirectToAction("ListadoMedicamento");

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
            if (id == null || _context.Medicamento == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamento.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            return View(medicamento);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Medicamento medicamento)
        {
            if (id != medicamento.MedicamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Medicamento actualizado " +
                        "exitosamente!!!";
                    return RedirectToAction("ListadoMedicamento");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error " +
                        "al actualizar");
                }
            }
            return View(medicamento);
        }


        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Medicamento == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamento
                .FirstOrDefaultAsync(m => m.MedicamentoID == id);

            if (medicamento == null)
            {
                return NotFound();
            }

            try
            {
                _context.Medicamento.Remove(medicamento);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "medicamento eliminado exitosamente!!!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }

            return RedirectToAction(nameof(ListadoMedicamento));
        }
        public IActionResult Index()
        {
            return View();
        }









    }
}