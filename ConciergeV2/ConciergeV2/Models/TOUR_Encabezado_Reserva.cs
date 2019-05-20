//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConciergeV2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TOUR_Encabezado_Reserva
    {
        [Display(Name = "Código")]
        public int CodReserva { get; set; }
        [Display(Name = "Reserva Opera")]
        public string ReservaOpera { get; set; }
        [Display(Name = "Nombre huesped")]
        [Required]
        public string NomHuesped { get; set; }
        [Display(Name = "Número habitación")]
        public Nullable<int> NumRoom { get; set; }
        [Display(Name = "Check In")]
        public Nullable<System.DateTime> Checkin { get; set; }
        [Display(Name = "Check Out")]
        public Nullable<System.DateTime> Checkout { get; set; }
        [Display(Name = "Fecha registro")]
        [Required]
        public Nullable<System.DateTime> FecReg { get; set; }
        [Display(Name = "Usuario registro")] 
        [Required]
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
        [Display(Name = "Precio adulto")]
        [Required]
        public Nullable<int> PaxAdul { get; set; }
        [Display(Name = "Precio adulto mayor")]
        [Required]
        public Nullable<int> PaxAdulM { get; set; }
        [Display(Name = "Precio niño")]
        [Required]
        public Nullable<int> PaxNino { get; set; }
        [Display(Name = "Total")]
        [Required]
        public Nullable<decimal> Total { get; set; }
        [Display(Name = "Fecha")]
        [Required]
        public Nullable<System.DateTime> Fecha { get; set; }
        [Display(Name = "Hora")]
        [Required]
        public Nullable<System.TimeSpan> Hora { get; set; }
        [Display(Name = "Regreso aproximado")]
        [Required]
        public Nullable<System.TimeSpan> ReturnTime { get; set; }
    
        public virtual TOUR_Catalogo_Tour TOUR_Catalogo_Tour { get; set; }
        public virtual TOUR_Operadores TOUR_Operadores { get; set; }
    }
}
