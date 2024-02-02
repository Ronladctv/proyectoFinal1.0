using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proyectoFinal.Models.Entidades
{
    public class Pacientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacienteID { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Nombre del Paciente es obligatorio.")]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóú\\s]+$", ErrorMessage = "Ingresa solo letras y espacios, no números ni caracteres especiales.")]
        public string NombrePaciente { get; set; }

        [Required(ErrorMessage = "El campo Apellido del Paciente es obligatorio.")]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóú\\s]+$", ErrorMessage = "Ingresa solo letras y espacios, no números ni caracteres especiales.")]
        public string ApellidoPaciente { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingresa una dirección de correo electrónico válida.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Edad es obligatorio.")]
        [Range(1, 150, ErrorMessage = "Ingresa una edad válida.")]
        public int Edad { get; set; }
    }
}
