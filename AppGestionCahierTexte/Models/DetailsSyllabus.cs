using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCahierTexte.Models
{
    public class DetailsSyllabus
    {
        [Key]
        public int IdDetailsSyllabus { get; set; }

        // ── Séance ────────────────────────────────────────────────────────────
        [Required, MaxLength(20)]
        public string SeanceSyllabus { get; set; }

        // ── Contenu ───────────────────────────────────────────────────────────
        [Required, MaxLength(500)]
        public string ContenuSyllabus { get; set; }

        // ── Durée (en heures, ex: 1.5 = 1h30) ────────────────────────────────
        public double? DureeSyllabus { get; set; }

        // ── Clé étrangère Syllabus ────────────────────────────────────────────
        [Required]
        public int SyllabusId { get; set; }
        [ForeignKey("SyllabusId")]
        public virtual Syllabus Syllabus { get; set; }
    }
}