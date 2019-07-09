using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    [MetadataType(typeof(SPA_Servicios.Metadata))]   
    public partial class SPA_Servicios
    {
        sealed class Metadata
        {
            [Display(Name = "Código servicio")]
            [Required]
            [StringLength(6, MinimumLength = 1)]
            public string CodSer { get; set; }
            [Display(Name = "Nombre servicio")]
            [Required]
            public string NomSer { get; set; }
            [Display(Name = "Descripción servicio")]
            [Required]
            public string DesSer { get; set; }
            [Display(Name = "Duración servicio")]
            [Required]
            public Nullable<System.TimeSpan> DurSer { get; set; }
            [Display(Name = "Precio servicio")]
            [Required]
            public Nullable<decimal> PreSer { get; set; }
        }
    }
}