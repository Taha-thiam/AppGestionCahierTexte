using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    public class AnneeAcademique
    {
        [Key]
        public int IdAnneeAcademique { get; set; }

        [Required, MaxLength(10)]
        public string LibelleAnneeAcademique { get; set; }

        [Required]
        public int ValueAnneeAcademique { get; set; }=DateTime.Now.Year;

    }
}
