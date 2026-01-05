using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    public class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }
        [Required, MaxLength(80)]
        public string NomUtilisateur { get; set; }
        [Required, MaxLength(80)]
        public string PrenomUtilisateur { get; set; }
        [MaxLength(300)]
        public string AdresseUtilisateur { get; set; }
        [Required, MaxLength(80)]
        public string EmailUtilisateur { get; set; }
        [Required, MaxLength(15)]
        public string TelephoneUtilisateur { get; set; }
        [Required, MaxLength(20)]
        public string Identifiant { get; set; }
        [Required, MaxLength(300)]
        public string MotDePasse { get; set; }
    }
}
