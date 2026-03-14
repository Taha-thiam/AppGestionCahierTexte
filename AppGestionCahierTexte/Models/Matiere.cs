using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppGestionCahierTexte.Models
{
    public class Matiere
    {
        [Key]
        public int idMatiere { get; set; }

        [Required, MaxLength(200)]
        public string libelleMatiere { get; set; }

        [Required]
        public int VolumeHoraireMatiere { get; set; }

        // Ex: "L1", "L2", "M1", "M2"
        [Required, MaxLength(80)]
        public string Niveau { get; set; }

        // Une matière peut avoir plusieurs syllabus
        public virtual ICollection<Syllabus> Syllabuses { get; set; }
    }

    public class printMatiere
            {
        public string libelleMatiere { get; set; }
        public int VolumeHoraireMatiere { get; set; }
        public string Niveau { get; set; }
    }
}