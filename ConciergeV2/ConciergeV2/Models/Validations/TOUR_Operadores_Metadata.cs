using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    [MetadataType(typeof(TOUR_Operadores.Metadata))]
    public partial class TOUR_Operadores
    {
        sealed class Metadata
        {
            [Display(Name = "Código operador")]
            [Required]
            public int CodCom { get; set; }
            [Display(Name = "Nombre operador")]
            [Required]
            public string NomCom { get; set; }
            [Display(Name = "Télefono")]
            [Required]
            [Phone]
            public string TelCom { get; set; }
            [Display(Name = "Email")]
            [EmailAddress]
            public string EmaCom { get; set; }
            [Display(Name = "Contacto 1")]
            public string Contacto1 { get; set; }
            [Display(Name = "Télefono 1")]
            [Phone]
            public string Telcon1 { get; set; }
            [Display(Name = "Email")]
            [EmailAddress]
            public string EmaCon1 { get; set; }
            [Display(Name = "Contacto 2")]
            public string Contacto2 { get; set; }
            [Display(Name = "Télefono 2")]
            [Phone]
            public string Telcon2 { get; set; }
            [Display(Name = "Email")]
            [EmailAddress]
            public string Emacon2 { get; set; }
        }
    }
}