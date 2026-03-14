namespace AppGestionCahierTexte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnneeAcademiques",
                c => new
                    {
                        IdAnneeAcademique = c.Int(nullable: false, identity: true),
                        LibelleAnneeAcademique = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        ValueAnneeAcademique = c.Int(nullable: false),
                        EstActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAnneeAcademique);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        IdClasse = c.Int(nullable: false, identity: true),
                        LibelleClasse = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        NiveauClasse = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        IdAnneeAcademique = c.Int(nullable: false),
                        IdResponsableClasse = c.Int(),
                    })
                .PrimaryKey(t => t.IdClasse)
                .ForeignKey("dbo.AnneeAcademiques", t => t.IdAnneeAcademique, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.IdResponsableClasse)
                .Index(t => t.IdAnneeAcademique)
                .Index(t => t.IdResponsableClasse);
            
            CreateTable(
                "dbo.CahierTextes",
                c => new
                    {
                        IdCahierTexte = c.Int(nullable: false, identity: true),
                        TitreCahierTexte = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        DescriptionCahierTexte = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        DateCreation = c.DateTime(nullable: false, precision: 0),
                        IdClasse = c.Int(),
                        ResponsableClasse_IdUtilisateur = c.Int(),
                        ChefDepartement_IdUtilisateur = c.Int(),
                    })
                .PrimaryKey(t => t.IdCahierTexte)
                .ForeignKey("dbo.Classes", t => t.IdClasse)
                .ForeignKey("dbo.Utilisateurs", t => t.ResponsableClasse_IdUtilisateur)
                .ForeignKey("dbo.Utilisateurs", t => t.ChefDepartement_IdUtilisateur)
                .Index(t => t.IdClasse)
                .Index(t => t.ResponsableClasse_IdUtilisateur)
                .Index(t => t.ChefDepartement_IdUtilisateur);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        IdUtilisateur = c.Int(nullable: false, identity: true),
                        NomUtilisateur = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        PrenomUtilisateur = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        AdresseUtilisateur = c.String(maxLength: 300, storeType: "nvarchar"),
                        EmailUtilisateur = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        TelephoneUtilisateur = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        Identifiant = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        MotDePasse = c.String(nullable: false, maxLength: 300, storeType: "nvarchar"),
                        MatriculeResponsable = c.String(maxLength: 20, storeType: "nvarchar"),
                        IdClasse = c.Int(),
                        IdCahierTexte = c.Int(),
                        MatriculeProfesseur = c.String(maxLength: 80, storeType: "nvarchar"),
                        Specialite = c.String(maxLength: 100, storeType: "nvarchar"),
                        NomDepartement = c.String(maxLength: 100, storeType: "nvarchar"),
                        Role = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdUtilisateur)
                .ForeignKey("dbo.CahierTextes", t => t.IdCahierTexte)
                .ForeignKey("dbo.Classes", t => t.IdClasse)
                .Index(t => t.IdClasse)
                .Index(t => t.IdCahierTexte);
            
            CreateTable(
                "dbo.Syllabus",
                c => new
                    {
                        IdSyllabus = c.Int(nullable: false, identity: true),
                        LibelleSyllabus = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        DescriptionSyllabus = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        VolumeHoraireSyllabus = c.Int(),
                        IdMatiere = c.Int(nullable: false),
                        IdClasse = c.Int(nullable: false),
                        IdProfesseur = c.Int(),
                    })
                .PrimaryKey(t => t.IdSyllabus)
                .ForeignKey("dbo.Classes", t => t.IdClasse, cascadeDelete: true)
                .ForeignKey("dbo.Matieres", t => t.IdMatiere, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.IdProfesseur)
                .Index(t => t.IdMatiere)
                .Index(t => t.IdClasse)
                .Index(t => t.IdProfesseur);
            
            CreateTable(
                "dbo.DetailsSyllabus",
                c => new
                    {
                        IdDetailsSyllabus = c.Int(nullable: false, identity: true),
                        SeanceSyllabus = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        ContenuSyllabus = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        DureeSyllabus = c.Double(),
                        SyllabusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetailsSyllabus)
                .ForeignKey("dbo.Syllabus", t => t.SyllabusId, cascadeDelete: true)
                .Index(t => t.SyllabusId);
            
            CreateTable(
                "dbo.Matieres",
                c => new
                    {
                        idMatiere = c.Int(nullable: false, identity: true),
                        libelleMatiere = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        VolumeHoraireMatiere = c.Int(nullable: false),
                        Niveau = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idMatiere);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CahierTextes", "ChefDepartement_IdUtilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.Syllabus", "IdProfesseur", "dbo.Utilisateurs");
            DropForeignKey("dbo.Syllabus", "IdMatiere", "dbo.Matieres");
            DropForeignKey("dbo.DetailsSyllabus", "SyllabusId", "dbo.Syllabus");
            DropForeignKey("dbo.Syllabus", "IdClasse", "dbo.Classes");
            DropForeignKey("dbo.Classes", "IdResponsableClasse", "dbo.Utilisateurs");
            DropForeignKey("dbo.Utilisateurs", "IdClasse", "dbo.Classes");
            DropForeignKey("dbo.Utilisateurs", "IdCahierTexte", "dbo.CahierTextes");
            DropForeignKey("dbo.CahierTextes", "ResponsableClasse_IdUtilisateur", "dbo.Utilisateurs");
            DropForeignKey("dbo.CahierTextes", "IdClasse", "dbo.Classes");
            DropForeignKey("dbo.Classes", "IdAnneeAcademique", "dbo.AnneeAcademiques");
            DropIndex("dbo.DetailsSyllabus", new[] { "SyllabusId" });
            DropIndex("dbo.Syllabus", new[] { "IdProfesseur" });
            DropIndex("dbo.Syllabus", new[] { "IdClasse" });
            DropIndex("dbo.Syllabus", new[] { "IdMatiere" });
            DropIndex("dbo.Utilisateurs", new[] { "IdCahierTexte" });
            DropIndex("dbo.Utilisateurs", new[] { "IdClasse" });
            DropIndex("dbo.CahierTextes", new[] { "ChefDepartement_IdUtilisateur" });
            DropIndex("dbo.CahierTextes", new[] { "ResponsableClasse_IdUtilisateur" });
            DropIndex("dbo.CahierTextes", new[] { "IdClasse" });
            DropIndex("dbo.Classes", new[] { "IdResponsableClasse" });
            DropIndex("dbo.Classes", new[] { "IdAnneeAcademique" });
            DropTable("dbo.Matieres");
            DropTable("dbo.DetailsSyllabus");
            DropTable("dbo.Syllabus");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.CahierTextes");
            DropTable("dbo.Classes");
            DropTable("dbo.AnneeAcademiques");
        }
    }
}
