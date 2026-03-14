using System.Data.Entity;

namespace AppGestionCahierTexte.Models
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class BdCahierTexteContext : DbContext
    {
        public BdCahierTexteContext()
            : base("connCahiertexte")
        {
        }



        public DbSet<AnneeAcademique> AnneeAcademiques { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Syllabus> Syllabuses { get; set; }
        public DbSet<DetailsSyllabus> DetailsSyllabuses { get; set; }
        public DbSet<CahierTexte> CahierTextes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<ResponsableClasse> ResponsableClasses { get; set; }
        public DbSet<ChefDepartement> ChefDepartements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ── TPH Utilisateur ───────────────────────────────────────────────
            modelBuilder.Entity<Utilisateur>()
                .Map<Professeur>(m => m.Requires("Role").HasValue("Professeur"))
                .Map<ResponsableClasse>(m => m.Requires("Role").HasValue("ResponsableClasse"))
                .Map<ChefDepartement>(m => m.Requires("Role").HasValue("ChefDepartement"));

            // ── Classe → ResponsableClasse (1 responsable gère plusieurs classes)
            modelBuilder.Entity<Classe>()
                .HasOptional(c => c.ResponsableClasse)
                .WithMany(r => r.Classes)
                .HasForeignKey(c => c.IdResponsableClasse)
                .WillCascadeOnDelete(false);

            // ── CahierTexte → Classe (optionnel) ──────────────────────────────
            modelBuilder.Entity<CahierTexte>()
                .HasOptional(c => c.Classe)
                .WithMany(cl => cl.CahierTextes)
                .HasForeignKey(c => c.IdClasse)
                .WillCascadeOnDelete(false);

            // ── ResponsableClasse → Classe (FK directe, sans cascade) ─────────
            modelBuilder.Entity<ResponsableClasse>()
                .HasOptional(r => r.Classe)
                .WithMany()
                .HasForeignKey(r => r.IdClasse)
                .WillCascadeOnDelete(false);

            // ── ResponsableClasse → CahierTexte (FK directe, sans cascade) ────
            modelBuilder.Entity<ResponsableClasse>()
                .HasOptional(r => r.CahierTexte)
                .WithMany()
                .HasForeignKey(r => r.IdCahierTexte)
                .WillCascadeOnDelete(false);
        }
    }
}