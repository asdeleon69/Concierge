using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    [MetadataType(typeof(SPA_Detalle_Reserva.Metadata))]
    public partial class SPA_Detalle_Reserva
    {
        sealed class Metadata
        {
            [Display(Name = "Código Reserva")]
            public int CodReserva { get; set; }
            [Display(Name = "Número registro")]
            [Required]
            public int Numreg { get; set; }
            [Display(Name = "Fecha/Hora registro")]
            [Required]
            public Nullable<System.DateTime> FecHoraRes { get; set; }
            [Display(Name = "Servicio")]
            [Required]
            public string CodSer { get; set; }
            [Display(Name = "Sala")]
            [Required]
            public string CodSala { get; set; }
            [Display(Name = "Terapeuta")]
            [Required]
            public Nullable<int> CodTerap { get; set; }
            [Display(Name = "Notas")]
            public string Notas { get; set; }
            [Display(Name = "Nombre Huesped")]
            [Required]
            public string NomHues { get; set; }
        }
    }
}