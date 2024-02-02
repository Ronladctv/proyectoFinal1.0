using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace proyectoFinal.Models.Entidades
{
    public class Doctores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "La cédula debe contener solo números.")]
        public string Cedula { get; set; }


        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El formato del teléfono no es válido.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; }



        public Especialidad Especialidades { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios Usuarios { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un Usuario")]
        public int UsuarioId { get; set; }



        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar una Especialidad.")]

        public int Especialidadid { get; set; }


        [NotMapped]

        public IEnumerable<SelectListItem> Especialidad { get; set; }


        [NotMapped]

        public IEnumerable<SelectListItem> Usuario { get; set; }
    }
}
