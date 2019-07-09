using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    [MetadataType(typeof(TRAN_Tipo_Transporte.Metadata))]
    public partial class TRAN_Tipo_Transporte
    {
        sealed class Metadata
        {
            [Display(Name = "Código")]
            [Required]
            public int Codtip { get; set; }
            [Display(Name = "Descripción")]
            [Required]
            public string Destip { get; set; }
        }
    }
}