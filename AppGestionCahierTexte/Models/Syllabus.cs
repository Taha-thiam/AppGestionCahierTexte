using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    public class Syllabus
    {
        [Key]
        public int IdSyllabus { get; set; }
        [Required, MaxLength(80)]
        public string LibelleSyllabus { get; set; }
        [Required, MaxLength(500)]
        public string DescriptionSyllabus { get; set; }
        public int? VolumeHoraireSyllabus { get; set; }
        [Required, MaxLength(20)]
        public String NiveauSyllabus { get; set; }

    }
}
