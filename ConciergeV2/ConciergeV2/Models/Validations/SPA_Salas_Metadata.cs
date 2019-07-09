using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    [MetadataType(typeof(SPA_Salas.Metadata))]
    public partial class SPA_Salas
    {
        sealed class Metadata
        {
            [Display(Name = "Código sala")]
            [Required]
            [StringLength(5, MinimumLength = 1)]
            public string CodSala { get; set; }
            [Display(Name = "Descripción sala")]
            [Required]
            public string DesSala { get; set; }
            [Display(Name = "Caracteristicas sala")]
            [Required]
            public string CarSala { get; set; }
        }
    }
}