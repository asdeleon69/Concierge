using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    [MetadataType(typeof(TOUR_Catalogo_Tour.Metadata))]
    public partial class TOUR_Catalogo_Tour
    {
        sealed class Metadata
        {
            [Display(Name = "Código tour")]
            public int CodTour { get; set; }
            [Display(Name = "Nombre tour")]
            [Required]
            public string NomTour { get; set; }
            [Display(Name = "Descripción tour")]
            [Required]
            public string DesTour { get; set; }
            [Display(Name = "Duración tour")]
            [Required]
            public Nullable<System.TimeSpan> DurTour { get; set; }
            [Display(Name = "Precio adulto")]
            [Required]
            public Nullable<decimal> PreTourAdulto { get; set; }
            [Display(Name = "Precio adulto mayor")]
            [Required]
            public Nullable<decimal> PreTourAdultoM { get; set; }
            [Display(Name = "Precio niño")]
            [Required]
            public Nullable<decimal> PreTourNino { get; set; }
            [Display(Name = "Notas tour")]
            public string NotasTour { get; set; }
            [Display(Name = "Operador tour")]
            public Nullable<int> ComTour { get; set; }
        }
    }
}