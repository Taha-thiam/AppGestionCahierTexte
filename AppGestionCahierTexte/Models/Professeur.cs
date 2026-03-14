using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppGestionCahierTexte.Models
{
    public class Professeur : Utilisateur
    {
        [Required, MaxLength(80)]
        public string MatriculeProfesseur { get; set; }  // déjà bon si présent

        [Required, MaxLength(100)]
        public string Specialite { get; set; }  // ← renommer ici

        public virtual ICollection<Syllabus> Syllabuses { get; set; }
    }
}