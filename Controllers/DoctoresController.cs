using proyectoFinal.Models;
using proyectoFinal.Models.Entidades;
using proyectoFinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Ejercicio.Controllers
{
    [Authorize(Policy = "RequireLoggedIn")]
    [Authorize(Roles = "Admin")]
    public class DoctoresController : Controller
    {
        private readonly IServicioUsuarios _servicioUsuario;
        private readonly IServicioImagen _servicioImagen;
        private readonly IServicioLista _servicioLista;
        private readonly SMedicoContext _context;

        public DoctoresController(IServicioUsuarios servicioUsuario, IServicioImagen servicioImagen,
            IServicioLista servicioLista, SMedicoContext context)
        {
            _servicioUsuario = servicioUsuario;
            _servicioImagen = servicioImagen;
            _servicioLista = servicioLista;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> ListadoDoctores()
        {
            var doctoresList = await _context.Doctores
                .Include(d => d.Usuarios)
                .Include(d => d.Especialidades)
                .ToListAsync();

            return View(doctoresList);
        }

        public async Task<IActionResult> Crear()
        {
            Doctores doctores = new Doctores
            {
                Usuario = await _servicioLista.GetListaUsuario(),
                Especialidad = await _servicioLista.GetListaEspecialidades()
            };

            // Asigna las listas al ViewData para que estén disponibles en la vista
            ViewData["Especialidades"] = doctores.Especialidad;
            ViewData["Usuarios"] = doctores.Usuario;

            return View(doctores);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Doctores doctores)
        {
            // Cargar las listas antes de la validación del modelo
            doctores.Especialidad = await _servicioLista.GetListaEspecialidades();
            doctores.Usuario = await _servicioLista.GetListaUsuario();

            if (doctores.DoctorID!=null )
            {
                _context.Add(doctores);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Doctor creado exitosamente";

                return RedirectToAction("ListadoDoctores");
            }

            else
            {
                // Debug: Recopilar mensajes de error detallados en una lista
                var errorMessages = new List<string>();
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        errorMessages.Add($"{modelStateKey}: {error.ErrorMessage}");
                    }
                }

                // Agregar mensajes de error a ModelState después de salir del bucle
                foreach (var errorMessage in errorMessages)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }



            return View(doctores);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctores = await _context.Doctores.FindAsync(id);

            if (doctores == null)
            {
                return NotFound();
            }

            doctores.Especialidad = await _servicioLista.GetListaEspecialidades();
            doctores.Usuario = await _servicioLista.GetListaUsuario();

            return View(doctores);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Doctores doctores)
        {
            
                try
                {
                    var doctorexistente = await _context.Doctores.FindAsync(doctores.DoctorID);

                    if (doctorexistente == null)
                    {
                        return NotFound();
                    }

             

                doctorexistente.Cedula = doctores.Cedula;
                doctorexistente.Telefono = doctores.Telefono;
                doctorexistente.Direccion = doctores.Direccion;
                doctorexistente.Titulo= doctores.Titulo;
                doctorexistente.Usuario = doctores.Usuario;
                doctorexistente.Especialidad = doctores.Especialidad;


                await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Doctor Actualizado exitosamente";

                    return RedirectToAction("ListadoDoctores");
                }
                catch (Exception ex)
                {
                    TempData["alertMessage"] = ex;
                }
            
        

            doctores.Especialidad = await _servicioLista.GetListaEspecialidades();
            doctores.Usuario = await _servicioLista.GetListaUsuario();
            return View(doctores);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctores.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            try
            {
                _context.Doctores.Remove(doctor);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Doctor eliminado exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrió un error, no se pudo eliminar el doctor");
            }

            return RedirectToAction(nameof(ListadoDoctores));
        }

    }
}
