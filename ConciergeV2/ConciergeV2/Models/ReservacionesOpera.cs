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
    
    public partial class ReservacionesOpera
    {
        public int Id { get; set; }
        public string NoReserva { get; set; }
        public string Huesped { get; set; }
        public Nullable<System.DateTime> Checkin { get; set; }
        public Nullable<System.DateTime> Checkout { get; set; }
        public string Room { get; set; }
        public string email { get; set; }
    }
}
