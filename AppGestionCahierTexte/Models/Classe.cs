using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCahierTexte.Models
{
    public class Classe
    {
        [Key]
        public int IdClasse { get; set; }

        // Ex: "L1", "L2", "M1"
        [Required, MaxLength(20)]
        public string LibelleClasse { get; set; }

        // Ex: "Licence 1", "Master 2"
        [Required, MaxLength(80)]
        public string NiveauClasse { get; set; }

        [Required]
        public int IdAnneeAcademique { get; set; }
        [ForeignKey("IdAnneeAcademique")]
        public virtual AnneeAcademique AnneeAcademique { get; set; }

        // Responsable affecté à cette classe
        public int? IdResponsableClasse { get; set; }
        [ForeignKey("IdResponsableClasse")]
        public virtual ResponsableClasse ResponsableClasse { get; set; }

        public virtual ICollection<Syllabus> Syllabuses { get; set; }

        // ← seul ajout nécessaire pour la liaison avec CahierTexte
        public virtual ICollection<CahierTexte> CahierTextes { get; set; }
    }
}