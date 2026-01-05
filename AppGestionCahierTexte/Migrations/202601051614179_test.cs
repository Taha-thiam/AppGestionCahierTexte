namespace AppGestionCahierTexte.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "IdAnneeAcademique", "dbo.AnneeAcademiques");
            DropIndex("dbo.Classes", new[] { "IdAnneeAcademique" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Classes", "IdAnneeAcademique");
            AddForeignKey("dbo.Classes", "IdAnneeAcademique", "dbo.AnneeAcademiques", "IdAnneeAcademique", cascadeDelete: true);
        }
    }
}
