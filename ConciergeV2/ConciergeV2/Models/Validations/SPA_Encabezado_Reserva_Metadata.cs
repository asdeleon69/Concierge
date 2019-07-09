using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    [MetadataType(typeof(SPA_Encabezado_Reserva.Metadata))]
    public partial class SPA_Encabezado_Reserva
    {
        sealed class Metadata
        {
            [Display(Name = "Codigo reserva")]
            public int CodReserva { get; set; }
            [Display(Name = "Reserva Opera")]
            [Required]
            public string ReservaOpera { get; set; }
            [Display(Name = "Nombre huesped")]
            public string NomHuesped { get; set; }
            [Display(Name = "Habitación")]
            public string NumRoom { get; set; }
            [Display(Name = "Check in")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime> Checkin { get; set; }
            [Display(Name = "Check out")]
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
            [Display(Name = "Notas Cliente")]
            public string NotasCliente { get; set; }
            [EmailAddress]
            public string Email { get; set; }
        }
    }
}