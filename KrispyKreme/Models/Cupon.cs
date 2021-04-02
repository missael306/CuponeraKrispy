using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrispyKreme.Models
{
    [Table("Cupones")]
    public class Cupon
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CuponID { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Proporcione un titulo.")]
        public string Titulo { get; set; }
        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "Proporcione un codigo.")]
        public string Codigo { get; set; }
        [Display(Name = "Serie")]
        [Required(ErrorMessage = "Proporcione un núumero de serie.")]
        public string Serie { get; set; }

        public DateTime Vigencia { get; set; }
        #endregion

        #region Relaciones 
        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Seleecione una opción.")]
        public int EstatusID { get; set; }
        public virtual Estatus Estatus { get; set; }

        [Display(Name = "Establecimiento")]
        [Required(ErrorMessage = "Seleecione una opción.")]
        public int EstablecimientoID { get; set; }
        public virtual Establecimiento Establecimiento { get; set; }
        #endregion
    }
}