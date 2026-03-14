namespace AppGestionCahierTexte.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AppGestionCahierTexte.Models.BdCahierTexteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(AppGestionCahierTexte.Models.BdCahierTexteContext context)
        {
        }
    }
}