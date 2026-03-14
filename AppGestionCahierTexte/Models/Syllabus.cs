using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCahierTexte.Models
{
    public class Syllabus
    {
        [Key]
        public int IdSyllabus { get; set; }

        [Required, MaxLength(200)]
        public string LibelleSyllabus { get; set; }

        [Required, MaxLength(500)]
        public string DescriptionSyllabus { get; set; }

        public int? VolumeHoraireSyllabus { get; set; }

        // ── Clé étrangère Matière ─────────────────────────────────────────────
        [Required]
        public int IdMatiere { get; set; }
        [ForeignKey("IdMatiere")]
        public virtual Matiere Matiere { get; set; }

        // ── Clé étrangère Classe ──────────────────────────────────────────────
        [Required]
        public int IdClasse { get; set; }
        [ForeignKey("IdClasse")]
        public virtual Classe Classe { get; set; }

        // ── Professeur assigné (optionnel) ────────────────────────────────────
        public int? IdProfesseur { get; set; }
        [ForeignKey("IdProfesseur")]
        public virtual Professeur Professeur { get; set; }

        // ── Détails des séances ───────────────────────────────────────────────
        public virtual ICollection<DetailsSyllabus> DetailsSyllabuses { get; set; }
    }
}