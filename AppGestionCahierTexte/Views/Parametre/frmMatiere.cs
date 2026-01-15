using AppGestionCahierTexte.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmMatiere : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedMatiereId = null;

        private void Effacer()
        {
            txtLibelle.Text = string.Empty;
            txtVolumeHoraire.Text = string.Empty;
            txtNiveau.Text = string.Empty;
            DgMatiere.DataSource = db.Matieres.ToList();
            txtLibelle.Focus();
            _selectedMatiereId = null;

            // Réinitialiser l'état des boutons
            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
        }

        public frmMatiere()
        {
            InitializeComponent();
        }

        private void frmMatiere_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation des champs
                if (string.IsNullOrWhiteSpace(txtLibelle.Text))
                {
                    MessageBox.Show("Veuillez saisir le libellé de la matière.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLibelle.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtVolumeHoraire.Text) ||
                    !int.TryParse(txtVolumeHoraire.Text, out int volumeHoraire))
                {
                    MessageBox.Show("Veuillez saisir un volume horaire valide.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVolumeHoraire.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNiveau.Text))
                {
                    MessageBox.Show("Veuillez saisir le niveau.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNiveau.Focus();
                    return;
                }

                // Créer une nouvelle matière
                Matiere nouvelleMatiere = new Matiere
                {
                    libelleMatiere = txtLibelle.Text.Trim(),
                    VolumeHoraireMatiere = volumeHoraire,
                    Niveau = txtNiveau.Text.Trim()
                };

                // Ajouter à la base de données
                db.Matieres.Add(nouvelleMatiere);
                db.SaveChanges();

                MessageBox.Show("Matière ajoutée avec succès!",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Rafraîchir et vider les champs
                Effacer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgMatiere.SelectedRows.Count > 0)
                {
                    // Récupérer l'ID de la ligne sélectionnée
                    _selectedMatiereId = Convert.ToInt32(DgMatiere.SelectedRows[0].Cells["idMatiere"].Value);

                    // Charger les données dans les champs
                    var matiere = db.Matieres.Find(_selectedMatiereId);

                    if (matiere != null)
                    {
                        txtLibelle.Text = matiere.libelleMatiere;
                        txtVolumeHoraire.Text = matiere.VolumeHoraireMatiere.ToString();
                        txtNiveau.Text = matiere.Niveau;

                        // Activer les boutons Modifier et Supprimer
                        btnModifier.Enabled = true;
                        btnSupprimer.Enabled = true;
                        btnAjouter.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une ligne dans le tableau.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sélection: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedMatiereId == null)
                {
                    MessageBox.Show("Veuillez d'abord sélectionner une matière à modifier.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validation des champs
                if (string.IsNullOrWhiteSpace(txtLibelle.Text))
                {
                    MessageBox.Show("Veuillez saisir le libellé de la matière.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLibelle.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtVolumeHoraire.Text) ||
                    !int.TryParse(txtVolumeHoraire.Text, out int volumeHoraire))
                {
                    MessageBox.Show("Veuillez saisir un volume horaire valide.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVolumeHoraire.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNiveau.Text))
                {
                    MessageBox.Show("Veuillez saisir le niveau.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNiveau.Focus();
                    return;
                }

                // Récupérer la matière et modifier
                var matiere = db.Matieres.Find(_selectedMatiereId);

                if (matiere != null)
                {
                    matiere.libelleMatiere = txtLibelle.Text.Trim();
                    matiere.VolumeHoraireMatiere = volumeHoraire;
                    matiere.Niveau = txtNiveau.Text.Trim();

                    db.SaveChanges();

                    MessageBox.Show("Matière modifiée avec succès!",
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

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedMatiereId == null)
                {
                    MessageBox.Show("Veuillez d'abord sélectionner une matière à supprimer.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Demander confirmation
                DialogResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer cette matière ?",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var matiere = db.Matieres.Find(_selectedMatiereId);

                    if (matiere != null)
                    {
                        db.Matieres.Remove(matiere);
                        db.SaveChanges();

                        MessageBox.Show("Matière supprimée avec succès!",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Effacer();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLibelle_TextChanged(object sender, EventArgs e)
        {
            // Limiter à 200 caractères (contrainte du modèle)
            if (txtLibelle.Text.Length > 200)
            {
                txtLibelle.Text = txtLibelle.Text.Substring(0, 200);
                txtLibelle.SelectionStart = txtLibelle.Text.Length;
            }
        }

        private void txtVolumeHoraire_TextChanged(object sender, EventArgs e)
        {
            // Accepter uniquement les chiffres
            if (!string.IsNullOrEmpty(txtVolumeHoraire.Text))
            {
                if (!int.TryParse(txtVolumeHoraire.Text, out _))
                {
                    // Supprimer le dernier caractère saisi
                    int cursorPosition = txtVolumeHoraire.SelectionStart;
                    txtVolumeHoraire.Text = txtVolumeHoraire.Text.Remove(txtVolumeHoraire.Text.Length - 1);
                    txtVolumeHoraire.SelectionStart = cursorPosition > 0 ? cursorPosition - 1 : 0;
                }
            }
        }

        private void txtNiveau_TextChanged(object sender, EventArgs e)
        {
            // Limiter à 80 caractères (contrainte du modèle)
            if (txtNiveau.Text.Length > 80)
            {
                txtNiveau.Text = txtNiveau.Text.Substring(0, 80);
                txtNiveau.SelectionStart = txtNiveau.Text.Length;
            }
        }

     
    }
}