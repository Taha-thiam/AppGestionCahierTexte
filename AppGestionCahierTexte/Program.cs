using AppGestionCahierTexte.Models;
using AppGestionCahierTexte.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
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
            FirstUser();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmConnexion());
        }

        //Cette méthode cree le super user
        public static void FirstUser()
        {
            BdCahierTexteContext db = new BdCahierTexteContext();


            string pass = "passer123";
            using (MD5 md5Hash = MD5.Create())
            {
                pass = Crypto.GetMd5Hash(md5Hash, pass);

            }
            if (db.ChefDepartements.FirstOrDefault() == null)
            {
                ChefDepartement cd = new ChefDepartement()
                {
                    NomUtilisateur = "Thiam",
                    PrenomUtilisateur = "taha",
                    AdresseUtilisateur = "Mariste",
                    EmailUtilisateur = "taha@groupeisi.com ",
                    TelephoneUtilisateur = "78 663 66 66",
                    Identifiant = "tthiam",
                    MotDePasse = pass,
                };
                db.ChefDepartements.Add(cd);
                db.SaveChanges();
            }

        }
    }
}
