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
        private int? _selectedResponsableClasseId = null;


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
                EmailUtilisateur = txtEmail.Text,
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
            txtEmail.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtIdentifiant.Text = string.Empty;
            txtMatricule.Text = string.Empty;

            DgResponsableClasse.DataSource = db.ResponsableClasses.ToList();

            // ✅ Cacher la colonne MotDePasse
            if (DgResponsableClasse.Columns["MotDePasse"] != null)
                DgResponsableClasse.Columns["MotDePasse"].Visible = false;

            txtNom.Focus();

            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
        }


        private void frmResponsableClasse_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            try
            {
                if (_selectedResponsableClasseId == null)
                {
                    MessageBox.Show("Veuillez d'abord sélectionner une classe à modifier.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validation des champs
                if (string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MessageBox.Show("Veuillez saisir le Nom.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNom.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPrenom.Text))
                {
                    MessageBox.Show("Veuillez saisir le Prenom.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrenom.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtAdresse.Text))
                {
                    MessageBox.Show("Veuillez saisir l'Adresse.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdresse.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Veuillez saisir l'Email.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTelephone.Text))
                {
                    MessageBox.Show("Veuillez saisir le telephone.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelephone.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
                {
                    MessageBox.Show("Veuillez saisir l' identifiant.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdentifiant.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtMatricule.Text))
                {
                    MessageBox.Show("Veuillez saisir le Matricule.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatricule.Focus();
                    return;
                }
                



               

              
             

                // Modifier la classe
                var r = db.ResponsableClasses.Find(_selectedResponsableClasseId);

                if (r != null)
                {
                    r.NomUtilisateur = txtNom.Text;
                    r.PrenomUtilisateur = txtPrenom.Text;
                    r.AdresseUtilisateur = txtAdresse.Text;
                    r.EmailUtilisateur = txtEmail.Text;
                    r.TelephoneUtilisateur = txtTelephone.Text;
                    r.Identifiant = txtIdentifiant.Text;
                    r.MatriculeResponsable = txtMatricule.Text;
                    db.SaveChanges();

                    MessageBox.Show("Responsable modifiée avec succès!",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Effacer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {

            txtNom.Text = DgResponsableClasse.CurrentRow.Cells[1].Value.ToString();
            txtPrenom.Text = DgResponsableClasse.CurrentRow.Cells[2].Value.ToString();
            txtAdresse.Text = DgResponsableClasse.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = DgResponsableClasse.CurrentRow.Cells[4].Value.ToString();
            txtTelephone.Text = DgResponsableClasse.CurrentRow.Cells[5].Value.ToString();
            txtIdentifiant.Text = DgResponsableClasse.CurrentRow.Cells[6].Value.ToString();
            txtMatricule.Text = DgResponsableClasse.CurrentRow.Cells[7].Value.ToString();

            if (DgResponsableClasse.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de la ligne sélectionnée
                _selectedResponsableClasseId = Convert.ToInt32(DgResponsableClasse.SelectedRows[0].Cells["idUtilisateur"].Value);

                // Charger les données dans les champs
                var respons = db.ResponsableClasses.Find(_selectedResponsableClasseId);

                if (respons != null)
                {
                    txtNom.Text = respons.NomUtilisateur;
                    txtPrenom.Text = respons.PrenomUtilisateur;
                    txtTelephone.Text = respons.TelephoneUtilisateur;
                    txtAdresse.Text = respons.AdresseUtilisateur;
                    txtEmail.Text = respons.EmailUtilisateur;
                    txtIdentifiant.Text = respons.Identifiant;
                    txtMatricule.Text = respons.MatriculeResponsable;


                    // Activer les boutons Modifier et Supprimer    
                    btnModifier.Enabled = true;
                    btnSupprimer.Enabled = true;
                    btnAjouter.Enabled = false;
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedResponsableClasseId == null)
                {
                    MessageBox.Show("Veuillez d'abord sélectionner un à responsable à supprimer.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Demander confirmation
                DialogResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer ce responsable  ?\n\nAttention : Cette action supprimera également toutes les données associées à ce responsable.",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var r = db.ResponsableClasses.Find(_selectedResponsableClasseId);

                    if (r != null)
                    {
                        db.ResponsableClasses.Remove(r);
                        db.SaveChanges();

                        MessageBox.Show("Responsable supprimée avec succès!",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Effacer();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression: {ex.Message}\n\nCette classe est peut-être utilisée dans d'autres tables.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
