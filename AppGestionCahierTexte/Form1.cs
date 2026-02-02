using AppGestionCahierTexte.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionCahierTexte
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {

            BdCahierTexteContext db = new BdCahierTexteContext();
            var leUser = db.Utilisateurs.Where(u => u.Identifiant == textIdentifiant.Text).FirstOrDefault();
            if (leUser == null)
            {
                MessageBox.Show("Identifiant ou mot de passe incorrect");
            }
            else
            { 
                using (MD5 md5Hash = MD5.Create())
                {
                    bool isValid = Shared.Crypto.VerifyMd5Hash(md5Hash, textMotDePasse.Text, leUser.MotDePasse);
                    if (!isValid)
                    {
                        MessageBox.Show("Identifiant ou mot de passe incorrect");
                        return;
                    }
                    else
                    {
                        string profil = "";
                        if (db.ResponsableClasses.Any(r => r.IdUtilisateur == leUser.IdUtilisateur))
                        {   
                            profil = "ResponsableClasse";
                        }

                        frmMDI f = new frmMDI();
                        f.profil = profil;
                        f.Show();
                        this.Hide();
                    }


                }


            }
        }

       
    }
}
