using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    public class ResponsableClasse: Utilisateur
    {
        [Required, MaxLength(10)]
        public String MatriculeResponsable { get; set; }
    } 
}
