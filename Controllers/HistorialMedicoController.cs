using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoFinal.Models;
using proyectoFinal.Models.Entidades;
using proyectoFinal.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejercicio.Controllers
  
{
    [Authorize(Policy = "RequireLoggedIn")]
    [Authorize(Roles = "Admin,Usuario,Doctor")]
    public class HistorialMedicoController : Controller
    {
        private readonly IServicioLista _servicioLista;
        private readonly SMedicoContext _context;

        public HistorialMedicoController(IServicioLista servicioLista, SMedicoContext context)
        {
            _servicioLista = servicioLista;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListadoHistorialMedico()
        {
            var historialesList = await _context.HistorialMedico
                .Include(h => h.Pacientes)
                .Include(h => h.Medicamento)
                .ToListAsync();

            return View(historialesList);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var historialMedico = new HistorialMedico
            {
                Paciente = await _servicioLista.GetListaPaciente(),
                Medicamentos = await _servicioLista.GetListaMedicamentos()
            };

            // Asigna las listas al ViewData para que estén disponibles en la vista
            ViewData["Pacientes"] = historialMedico.Paciente;
            ViewData["Medicamentos"] = historialMedico.Medicamentos;

            return View(historialMedico);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(HistorialMedico historialMedico)
        {
            // Cargar las listas antes de la validación del modelo
            historialMedico.Paciente = await _servicioLista.GetListaPaciente();
            historialMedico.Medicamentos = await _servicioLista.GetListaMedicamentos();

            
                _context.Add(historialMedico);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Historial Médico creado exitosamente";

                return RedirectToAction("ListadoHistorialMedico");
            

          
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialMedico = await _context.HistorialMedico.FindAsync(id);

            if (historialMedico == null)
            {
                return NotFound();
            }

            historialMedico.Paciente = await _servicioLista.GetListaPaciente();
            historialMedico.Medicamentos = await _servicioLista.GetListaMedicamentos();

            return View(historialMedico);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(HistorialMedico historialMedico)
        {
            
                try
                {
                    var historialExistente = await _context.HistorialMedico.FindAsync(historialMedico.HistorialID);

                    if (historialExistente == null)
                    {
                        return NotFound();
                    }

                historialExistente.NumHistorial = historialMedico.NumHistorial;
                historialExistente.Detalles = historialMedico.Detalles;
                historialExistente.AntecedentesFamiliares = historialMedico.AntecedentesFamiliares;
                historialExistente.AntecedentesPersonales = historialMedico.AntecedentesPersonales;
                historialExistente.Alergias = historialMedico.Alergias;
                historialExistente.NotasObservaciones = historialMedico.NotasObservaciones;
                historialExistente.Medicamento = historialMedico.Medicamento;
                historialExistente.Pacientes = historialMedico.Pacientes;

                _context.Update(historialExistente);
                await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Historial Médico Actualizado exitosamente";

                    return RedirectToAction("ListadoHistorialMedico");
                }
                catch (Exception ex)
                {
                    TempData["alertMessage"] = ex;
                }
            

            historialMedico.Paciente = await _servicioLista.GetListaPaciente();
            historialMedico.Medicamentos = await _servicioLista.GetListaMedicamentos();
            return View(historialMedico);
        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialMedico = await _context.HistorialMedico.FindAsync(id);

            if (historialMedico == null)
            {
                return NotFound();
            }

            try
            {
                _context.HistorialMedico.Remove(historialMedico);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Historial Médico eliminado exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrió un error, no se pudo eliminar el historial médico");
            }

            return RedirectToAction(nameof(ListadoHistorialMedico));
        }


    }
}
