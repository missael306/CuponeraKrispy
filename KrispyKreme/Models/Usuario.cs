using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrispyKreme.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { get; set; }

        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Seleccione una opción.")]
        public int PerfilID { get; set; }
        public virtual Perfil Perfil { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Proporcione un nombre.")]
        public string Nombre { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Proporcione un email.")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Proporcione una contraseña.")]
        public string Contrasena { get; set; }
        #endregion
    }
}