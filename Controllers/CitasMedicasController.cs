using proyectoFinal.Models;
using proyectoFinal.Models.Entidades;
using proyectoFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Ejercicio.Controllers
{
    [Authorize(Policy = "RequireLoggedIn")]
    [Authorize(Roles = "Admin,Usuario,Doctor")]

    public class CitasMedicasController : Controller
    {
        private readonly IServicioUsuarios _servicioUsuario;
        private readonly IServicioImagen _servicioImagen;
        private readonly IServicioLista _servicioLista;
        private readonly SMedicoContext _context;

        public CitasMedicasController(IServicioUsuarios servicioUsuario, IServicioImagen servicioImagen,
            IServicioLista servicioLista, SMedicoContext context)
        {
            _servicioUsuario = servicioUsuario;
            _servicioImagen = servicioImagen;
            _servicioLista = servicioLista;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListadoCitasMedicas()
        {
            var citasMedicasList = await _context.CitasMedicas
                .Include(c => c.Pacientes)
                .Include(c => c.Doctores)
                .ToListAsync();

            return View(citasMedicasList);
        }

        public async Task<IActionResult> Crear()
        {
            CitasMedicas citasMedicas = new CitasMedicas
            {
                Paciente = await _servicioLista.GetListaPaciente(),
                Doctor = await _servicioLista.GetListaDoctores()
            };

            // Asigna las listas al ViewData para que estén disponibles en la vista
            ViewData["Pacientes"] = citasMedicas.Paciente;
            ViewData["Doctores"] = citasMedicas.Doctor;

            return View(citasMedicas);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CitasMedicas citasMedicas)
        {
            // Cargar las listas antes de la validación del modelo
            citasMedicas.Paciente = await _servicioLista.GetListaPaciente();
            citasMedicas.Doctor = await _servicioLista.GetListaDoctores();

            if (citasMedicas.CitaID != null)
            {
                _context.Add(citasMedicas);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Cita médica creada exitosamente";

                return RedirectToAction("ListadoCitasMedicas");
            }

            return View(citasMedicas);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitasMedicas.FindAsync(id);

            if (citaMedica == null)
            {
                return NotFound();
            }

            citaMedica.Paciente = await _servicioLista.GetListaPaciente();
            citaMedica.Doctor = await _servicioLista.GetListaDoctores();

            return View(citaMedica);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CitasMedicas citasMedicas)
        {
            try
            {
                var citaMedicaExistente = await _context.CitasMedicas.FindAsync(citasMedicas.CitaID);

                if (citaMedicaExistente == null)
                {
                    return NotFound();
                }

                // Actualiza propiedades específicas del modelo
                citaMedicaExistente.Estado = citasMedicas.Estado;
                citaMedicaExistente.TipoConsulta = citasMedicas.TipoConsulta;
                citaMedicaExistente.Notas = citasMedicas.Notas;
                citaMedicaExistente.FechaHoraCita = citasMedicas.FechaHoraCita;
                citaMedicaExistente.Duracion = citasMedicas.Duracion;
                citaMedicaExistente.Pacientes = citasMedicas.Pacientes;
                citaMedicaExistente.Doctores = citasMedicas.Doctores;

                // Actualiza el resto de las propiedades según sea necesario

                _context.Update(citaMedicaExistente);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Cita médica actualizada exitosamente";

                return RedirectToAction("ListadoCitasMedicas");
            }
            catch (Exception ex)
            {
                TempData["alertMessage"] = ex;
            }

            citasMedicas.Paciente = await _servicioLista.GetListaPaciente();
            citasMedicas.Doctor = await _servicioLista.GetListaDoctores();
            return View(citasMedicas);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitasMedicas.FindAsync(id);

            if (citaMedica == null)
            {
                return NotFound();
            }

            try
            {
                _context.CitasMedicas.Remove(citaMedica);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Cita médica eliminada exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrió un error, no se pudo eliminar la cita médica");
            }

            return RedirectToAction(nameof(ListadoCitasMedicas));
        }


    }
}
