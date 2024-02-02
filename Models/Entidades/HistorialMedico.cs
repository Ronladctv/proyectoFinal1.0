using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace proyectoFinal.Models.Entidades
{
    public class HistorialMedico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistorialID { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo debe contener solo números.")]
        public string? NumHistorial { get; set; }

        [Required(ErrorMessage = "Los detalles son obligatorios.")]
        public string Detalles { get; set; }

        // Antecedentes médicos
        [Required(ErrorMessage = "Los antecedentes familiares son obligatorios.")]
        public string AntecedentesFamiliares { get; set; }

        [Required(ErrorMessage = "Los antecedentes personales son obligatorios.")]
        public string AntecedentesPersonales { get; set; }

        // Alergias
        [Required(ErrorMessage = "Las alergias son obligatorias.")]
        public string Alergias { get; set; }

        // Notas y observaciones adicionales
        [Required(ErrorMessage = "Las notas y observaciones son obligatorias.")]
        public string NotasObservaciones { get; set; }

        //relaciones 
        public Medicamento Medicamento { get; set; }

        [ForeignKey("Pacienteid")]
        public Pacientes Pacientes { get; set; }



        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un Medicamento.")]

        public int Medicamentoid { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un Paciente.")]

        public int Pacienteid { get; set; }



        [NotMapped]

        public IEnumerable<SelectListItem> Paciente { get; set; }

        [NotMapped]

        public IEnumerable<SelectListItem> Medicamentos { get; set; }

    }
}
