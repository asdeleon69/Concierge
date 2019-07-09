using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConciergeV2.Models
{
    [MetadataType(typeof(TRAN_Pick_Drop.Metadata))]
    public partial class TRAN_Pick_Drop
    {
        sealed class Metadata
        {
            [Display(Name = "Código")]
            [Required]
            public int CodPick { get; set; }
            [Display(Name = "Descripción")]
            [Required]
            public string DesPick { get; set; }
        }
    }
}