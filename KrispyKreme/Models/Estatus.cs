using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrispyKreme.Models
{
    [Table("Estatus", Schema = "Cat")]
    public class Estatus
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstatusID { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Proporcione un nombre.")]
        public string Nombre { get; set; }
        #endregion
    }
}