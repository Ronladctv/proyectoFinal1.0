using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectoFinal.Models;
using proyectoFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoFinal.Services
{
    public class ServicioLista : IServicioLista
    {
        private readonly SMedicoContext _context;

        public ServicioLista(SMedicoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<SelectListItem>> GetListaEspecialidades()
        {
            List<SelectListItem> list = await _context.Especialidad.Select(x => new SelectListItem
            {
                Text = x.NombreEspecialidad,
                Value = $"{x.EspecialidadID}"
            })
            .OrderBy(x => x.Text)
            .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una Especialidad...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaMedicamentos()
        {
            List<SelectListItem> list = await _context.Medicamento.Select(x => new SelectListItem
            {
                Text = x.NombreMedicamento,
                Value = $"{x.MedicamentoID}"
            })
            .OrderBy(x => x.Text)
            .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Medicamento...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaRoles()
        {
            List<SelectListItem> list = await _context.Roles.Select(x => new SelectListItem
            {
                Text = x.NombreRol,
                Value = $"{x.RolID}"
            })
            .OrderBy(x => x.Text)
            .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Rol..]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaUsuario()
        {
            List<SelectListItem> list = await _context.Usuarios.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = $"{x.UsuarioID}"
            })
            .OrderBy(x => x.Text)
            .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Usuario...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaCitasMedicas()
        {
            List<SelectListItem> list = await _context.CitasMedicas.Select(x => new SelectListItem
            {
                Text = x.TipoConsulta,
                Value = $"{x.CitaID}"
            })
            .OrderBy(x => x.Text)
            .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una Cita...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetListaPaciente()
        {
            List<SelectListItem> list = await _context.Pacientes.Select(x => new SelectListItem
            {
                Text = x.NombrePaciente,
                Value = $"{x.PacienteID}"
            })
            .OrderBy(x => x.Text)
            .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Paciente...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetHistorialMedico()
        {
            List<SelectListItem> list = await _context.HistorialMedico.Select(x => new SelectListItem
            {
                Text = x.NumHistorial,
                Value = $"{x.HistorialID}"
            })
            .OrderBy(x => x.Text)
            .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Historial...]",
                Value = "0"
            });

            return list;
        }
        public async Task<IEnumerable<SelectListItem>> GetListaDoctores()
        {
            List<SelectListItem> list = await _context.Doctores.Select(x => new SelectListItem
            {
                Text = x.Cedula,
                Value = $"{x.DoctorID}"
            })
            .OrderBy(x => x.Text)
            .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Historial...]",
                Value = "0"
            });

            return list;
        }

    }
}
