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

    public partial class SPA_Encabezado_Reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPA_Encabezado_Reserva()
        {
            this.SPA_Detalle_Reserva = new HashSet<SPA_Detalle_Reserva>();
        }

        [Display(Name = "Codigo reserva")]
        public int CodReserva { get; set; }
        [Display(Name = "Reserva Opera")]
        public string ReservaOpera { get; set; }
        [Display(Name = "Nombre huesped")]
        [Required]
        public string NomHuesped { get; set; }
        [Display(Name = "Habitación")]
        public Nullable<int> NumRoom { get; set; }
        [Display(Name = "Check in")]
        public Nullable<System.DateTime> Checkin { get; set; }
        [Display(Name = "Check out")]
        public Nullable<System.DateTime> Checkout { get; set; }
        [Display(Name = "Fecha registro")]
        public Nullable<System.DateTime> FecReg { get; set; }
        [Display(Name = "Usuario registro")]
        [Required]
        public string UsrReg { get; set; }
        [Display(Name = "Alergias")]
        public string Alergias { get; set; }
        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }
        [Display(Name = "Notas Cliente")]
        public string NotasCliente { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPA_Detalle_Reserva> SPA_Detalle_Reserva { get; set; }
    }
}