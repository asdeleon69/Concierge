using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    [MetadataType(typeof(User.Metadata))]
    public partial class User
    {
        sealed class Metadata
        {
            public int Id { get; set; }
            [Display(Name = "Nombre")]
            [Required]
            [StringLength(50, ErrorMessage = "No se permite ingresar más de 50 caracteres de longitud")]
            public string Nombre { get; set; }
            [Display(Name = "Usuario")]
            [Required]
            public string Usuario { get; set; }
            [Display(Name = "Contraseña")]
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            //[NotMapped]
            //[Required]
            //[Display(Name = "Digite nuevamente su contraseña")]
            ////atributo para comprar y confirmar que ambos campos son identicos
            //[Compare("Password", ErrorMessage = "Contraseña no concuerda.")]
            //[DataType(DataType.Password)]
            //public string PasswordConfirm { get; set; }
            [Display(Name = "Activo")]
            [Required]
            public Nullable<bool> Activo { get; set; }
            [Display(Name = "Nivel")]
            [Required]
            [Range(1, 2, ErrorMessage = "Seleccione 1 para usuario basico y 2 para administrador")]
            public Nullable<int> Nivel { get; set; }
        }
    }
}