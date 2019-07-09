using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    [MetadataType(typeof(SPA_Terapeutas.Metadata))]
    public partial class SPA_Terapeutas
    {
        sealed class Metadata
        {
            [Display(Name = "Código terapeuta")]
            [Required]
            public int CodTerap { get; set; }
            [Display(Name = "Nombre terapeuta")]
            public string NomTerap { get; set; }
        }
    }
}