using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proyectoFinal.Models.Entidades
{
    public class Medicamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicamentoID { get; set; }

        [Required(ErrorMessage = "El nombre del medicamento es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Solo se permiten letras y espacios en el tipo.")]
        public string NombreMedicamento { get; set; }

        [Required(ErrorMessage = "La forma farmacéutica es obligatoria.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Solo se permiten letras y espacios en el tipo.")]
        public string FormFarmaceutica { get; set; }

        [Required(ErrorMessage = "El tipo de medicamento es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Solo se permiten letras y espacios en el tipo.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "La concentración es obligatoria.")]
        public string Concentracion { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime FechaVencimiento { get; set; }
    }
}
