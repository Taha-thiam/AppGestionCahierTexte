using AppGestionCahierTexte.Models;
using AppGestionCahierTexte.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmResponsableClasse : Form
    {
        public frmResponsableClasse()
        {
            InitializeComponent();
        }

        BdCahierTexteContext db = new BdCahierTexteContext();

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string pass = "passer123";
            using (MD5 md5Hash = MD5.Create())
             {
                pass = Crypto.GetMd5Hash(md5Hash, pass);

            }
            ResponsableClasse responsableClasse = new ResponsableClasse()
            {
                NomUtilisateur = txtNom.Text,
                PrenomUtilisateur = txtPrenom.Text,
                AdresseUtilisateur = txtAdresse.Text,
                EmailUtilisateur = txtAdresse.Text,
                TelephoneUtilisateur = txtTelephone.Text,
                Identifiant = txtIdentifiant.Text,
                MotDePasse = pass,
                MatriculeResponsable = txtMatricule.Text
            };
            db.ResponsableClasses.Add(responsableClasse);
            db.SaveChanges();
            Effacer();
        }
        private void Effacer()
        {
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtAdresse.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtIdentifiant.Text = string.Empty;
            txtMatricule.Text = string.Empty;
            DgResponsableClasse.DataSource = db.ResponsableClasses.ToList();
            txtNom.Focus();

            // Réinitialiser l'état des boutons
            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;

        }

        private void frmResponsableClasse_Load(object sender, EventArgs e)
        {
            Effacer();
        }
    }
}
