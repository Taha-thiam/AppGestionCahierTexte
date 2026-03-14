using AppGestionCahierTexte.Models;
using AppGestionCahierTexte.Shared;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AppGestionCahierTexte
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                CreerSuperUtilisateur();
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"Erreur initialisation : {ex.Message}");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmConnexion());
        }

        /// <summary>
        /// Crée le chef de département par défaut si aucun n'existe encore.
        /// Identifiant : tthiam / Mot de passe : passer123
        /// </summary>
        private static void CreerSuperUtilisateur()
        {
            using (var db = new BdCahierTexteContext())
            {
                if (db.ChefDepartements.FirstOrDefault() != null)
                    return;

                string pass;
                using (MD5 md5 = MD5.Create())
                    pass = Crypto.GetMd5Hash(md5, "passer123");

                var cd = new ChefDepartement
                {
                    NomUtilisateur = "Thiam",
                    PrenomUtilisateur = "Taha",
                    AdresseUtilisateur = "Mariste",
                    EmailUtilisateur = "taha@groupeisi.com",
                    TelephoneUtilisateur = "78 663 66 66",
                    Identifiant = "tthiam",
                    MotDePasse = pass,
                    NomDepartement = "Informatique"
                };

                db.ChefDepartements.Add(cd);
                db.SaveChanges();
            }
        }
    }
}