using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proyectoFinal.Models.Entidades
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { get; set; }

[Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
    [StringLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 caracteres.")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "El campo Correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El campo Correo debe ser una dirección de correo electrónico válida.")]
    public string correo { get; set; }

        public string Clave { get; set; }

        public string URLFotoPerfil { get; set; }

        public string[] Roles { get; set; }
    }
}
