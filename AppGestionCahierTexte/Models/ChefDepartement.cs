using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppGestionCahierTexte.Models
{
    public class ChefDepartement : Utilisateur
    {
        // Ex: "Informatique", "Mathématiques"
        [Required, MaxLength(100)]
        public string NomDepartement { get; set; }

        // Le chef supervise les cahiers de texte
        public virtual ICollection<CahierTexte> CahiersTexteSupervises { get; set; }
    }
}