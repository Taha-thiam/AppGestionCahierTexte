using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCahierTexte.Models
{
    public class CahierTexte
    {
        [Key]
        public int IdCahierTexte { get; set; }

        [Required, MaxLength(150)]
        public string TitreCahierTexte { get; set; }

        [Required, MaxLength(250)]
        public string DescriptionCahierTexte { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;

        // Nullable : un cahier peut exister sans classe assignée
        public int? IdClasse { get; set; }
        [ForeignKey("IdClasse")]
        public virtual Classe Classe { get; set; }
    }
}