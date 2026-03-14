using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCahierTexte.Models
{
    public class ResponsableClasse : Utilisateur
    {
        [Required, MaxLength(20)]
        public string MatriculeResponsable { get; set; }

        // FK Classe (optionnel)
        public int? IdClasse { get; set; }
        [ForeignKey("IdClasse")]
        public virtual Classe Classe { get; set; }

        // FK CahierTexte (optionnel)
        public int? IdCahierTexte { get; set; }
        [ForeignKey("IdCahierTexte")]
        public virtual CahierTexte CahierTexte { get; set; }

        // Collections de navigation (existantes)
        public virtual ICollection<Classe> Classes { get; set; }
        public virtual ICollection<CahierTexte> CahiersTexte { get; set; }
    }
}