using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models.Validations
{
    [MetadataType(typeof(User.Metadata))]
    public partial class User
    {
        sealed class Metadata
        {
            public int Id { get; set; }
            [Display(Name = "Nombre:")]
            [Required]
            public string Nombre { get; set; }
            [Display(Name = "Usuario:")]
            [Required]
            public string Usuario { get; set; }
            [Display(Name = "Contraseña:")]
            [Required]
            public string Password { get; set; }
            [Display(Name = "Activo:")]
            public Nullable<bool> Activo { get; set; }
            [Display(Name = "Nivel:")]
            [Required]
            public Nullable<int> Nivel { get; set; }
        }
    }
}