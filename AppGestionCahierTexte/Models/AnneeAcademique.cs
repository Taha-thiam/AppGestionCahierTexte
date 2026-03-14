using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppGestionCahierTexte.Models
{
    public class AnneeAcademique
    {
        [Key]
        public int IdAnneeAcademique { get; set; }

        // Ex: "2024-2025"
        [Required, MaxLength(10)]
        public string LibelleAnneeAcademique { get; set; }

        [Required]
        public int ValueAnneeAcademique { get; set; } = DateTime.Now.Year;

        public bool EstActive { get; set; } = false;

        public virtual ICollection<Classe> Classes { get; set; }
    }
}