using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    public partial class TRAN_Encabezado_Reserva
    {
        [MetadataType(typeof(TRAN_Encabezado_Reserva.Metadata))]
        sealed class Metadata
        {
            [Display(Name = "Código reserva")]
            [Required]
            public int CodReserva { get; set; }
            [Display(Name = "Reserva Opera")]
            [Required]
            public string ReservaOpera { get; set; }
            [Display(Name = "Nombre huesped")]
            [Required]
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
            [Required]
            public Nullable<System.DateTime> FecReg { get; set; }
            [Display(Name = "Usuario registro")]
            public string UsrReg { get; set; }
            [Display(Name = "Alergias")]
            public string Alergias { get; set; }
            [Display(Name = "Observaciones")]
            public string Observaciones { get; set; }
            [Display(Name = "Notas")]
            public string NotasCliente { get; set; }
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }
            [Display(Name = "Tipo transporte")]
            [Required]
            public Nullable<int> TipoTran { get; set; }
            [Display(Name = "Pick up")]
            [Required]
            public Nullable<int> Pickup { get; set; }
            [Display(Name = "Drop off")]
            [Required]
            public Nullable<int> Dropoff { get; set; }
            [Display(Name = "Pax")]
            [Required]
            public Nullable<int> Pax { get; set; }
            [Display(Name = "Precio")]
            [Required]
            public Nullable<decimal> Precio { get; set; }
            [Display(Name = "Fecha")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Required]
            public Nullable<System.DateTime> Fecha { get; set; }
            [Display(Name = "Hora")]
            [Required]
            public Nullable<System.TimeSpan> Hora { get; set; }
            [Display(Name = "Aerolinea")]
            public string Aerolinea { get; set; }
            [Display(Name = "Número vuelo")]
            public string NoVuelo { get; set; }
        }
    }
}