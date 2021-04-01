using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrispyKreme.Models
{
    [Table("Perfiles", Schema = "Cat")]
    public class Perfil
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerfilID { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Proporcione un nombre.")]
        public string Nombre { get; set; }

        public bool PuedeVer { get; set; }
        public bool PuedeEditar { get; set; }
        public bool PuedeEliminar { get; set; }
        public bool PuedeExportar { get; set; }
        public bool PuedeCrear { get; set; }
        #endregion
    }
}