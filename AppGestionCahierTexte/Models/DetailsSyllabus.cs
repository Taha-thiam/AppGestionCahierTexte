using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Models
{
    public class DetailsSyllabus
    {
        [Key]
        public int IdDetailsSyllabus { get; set; }
        [Required, MaxLength(10)]
        public string SeanceSyllabus { get; set; }
        [Required, MaxLength(500)]
        public string ContenuSyllabus { get; set; } = null;
        public int? SyllabusId { get; set; }
        [ForeignKey("SyllabusId")]
        public Syllabus Syllabus { get; set; }

    }
}
