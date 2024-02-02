using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoFinal.Models.Entidades
{
    public enum EstadoCita
    {
        Programada,
        Cancelada,
        Realizada,
        // Agrega más estados según sea necesario
    }

   




    public class CitasMedicas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CitaID { get; set; }


        [Required(ErrorMessage = "El tipo de consulta es obligatorio.")]
        public string TipoConsulta { get; set; } // Revisión anual, Seguimiento, Emergencia, etc.

        [Required(ErrorMessage = "El estado de la cita es obligatorio.")]
        public EstadoCita Estado { get; set; } // Programada, Cancelada, Realizada, etc.

        [StringLength(255, ErrorMessage = "La longitud de las notas no puede superar los 255 caracteres.")]
        public string Notas { get; set; }


        [Required(ErrorMessage = "La fecha y hora de la cita son obligatorias.")]
        [DataType(DataType.DateTime, ErrorMessage = "El formato de fecha y hora no es válido.")]
        public DateTime FechaHoraCita { get; set; }

        [Required(ErrorMessage = "La duración estimada de la cita es obligatoria.")]
        [RegularExpression(@"^([0-9]|[0-1][0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "El formato de duración no es válido. Use HH:mm.")]
        public TimeSpan Duracion { get; set; } // Duración estimada de la cita

        [ForeignKey("PacienteId")]

        public Pacientes Pacientes { get; set; }

        [ForeignKey("Doctorid")]
        public Doctores Doctores { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un Paciente")]
        public int PacienteId { get; set; }



        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar algun Doctor")]

        public int Doctorid { get; set; }


        [NotMapped]

        public IEnumerable<SelectListItem> Paciente { get; set; }


        [NotMapped]

        public IEnumerable<SelectListItem> Doctor { get; set; }




    }
}
