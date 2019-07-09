using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models

{
    [MetadataType(typeof(TOUR_Encabezado_Reserva.Metadata))]
    public partial class TOUR_Encabezado_Reserva
    {
        sealed class Metadata
        {
            [Display(Name = "Código reserva")]
            public int CodReserva { get; set; }
            [Display(Name = "Reserva Opera")]
            [Required]
            public string ReservaOpera { get; set; }
            [Display(Name = "Nombre huesped")]
            public string NomHuesped { get; set; }
            [Display(Name = "Número habitación")]
            public string NumRoom { get; set; }
            [Display(Name = "Check In")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> Checkin { get; set; }
            [Display(Name = "Check Out")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> Checkout { get; set; }
            [Display(Name = "Fecha registro")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> FecReg { get; set; }
            [Display(Name = "Usuario registro")]
            public string UsrReg { get; set; }
            [Display(Name = "Alergias")]
            public string Alergias { get; set; }
            [Display(Name = "Observaciones")]
            public string Observaciones { get; set; }
            [Display(Name = "Notas")]
            public string NotasCliente { get; set; }
            [EmailAddress]
            public string Email { get; set; }
            [Display(Name = "Operador")]
            [Required]
            public Nullable<int> CodCom { get; set; }
            [Display(Name = "Tour")]
            [Required]
            public Nullable<int> CodTour { get; set; }
            [Display(Name = "Pax adulto")]
            [Required]
            public Nullable<int> PaxAdul { get; set; }
            [Display(Name = "Pax adulto mayor")]
            [Required]
            public Nullable<int> PaxAdulM { get; set; }
            [Display(Name = "Pax niño")]
            [Required]
            public Nullable<int> PaxNino { get; set; }
            [Display(Name = "Total")]
            [Required]
            public Nullable<decimal> Total { get; set; }
            [Display(Name = "Fecha")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Required]
            public Nullable<System.DateTime> Fecha { get; set; }
            [Display(Name = "Hora")]
            [Required]
            public Nullable<System.TimeSpan> Hora { get; set; }
            [Display(Name = "Regreso aproximado")]
            [Required]
            public Nullable<System.TimeSpan> ReturnTime { get; set; }

        }
    }
}